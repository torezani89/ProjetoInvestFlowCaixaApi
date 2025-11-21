using AutoMapper;
using InvestFlowCaixa.Application.Clientes.Dtos;
using InvestFlowCaixa.Application.PerfilRisco.Services;
using InvestFlowCaixa.Domain.Entities;
using InvestFlowCaixa.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace InvestFlowCaixa.Application.Clientes.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepo;
        private readonly IPerfilRiscoRepository _perfilRiscoRepo;
        private readonly ISenhaService _senhaService;
        private readonly IPerfilRiscoService _perfilRiscoService;
        private readonly ILogger<ClienteService> _logger;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository repository, IPerfilRiscoRepository perfilRiscoRepository, IPerfilRiscoService perfilRiscoService, 
            ISenhaService senhaService, ILogger<ClienteService> logger, IMapper mapper)
        {
            _clienteRepo = repository;
            _perfilRiscoRepo = perfilRiscoRepository;
            _perfilRiscoService = perfilRiscoService;
            _senhaService = senhaService;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ClienteRespostaDto> ObterPorIdAsync(int id)
        {
            _logger.LogInformation("Buscando cliente com ID {Id}", id);

            var cliente = await _clienteRepo.ObterClienteComPerfil(id);

            if (cliente is null)
            {
                _logger.LogWarning("Cliente com ID {Id} não encontrado", id);
                throw new KeyNotFoundException($"Cliente com ID {id} não encontrado.");
            }

            var clienteDto = _mapper.Map<ClienteRespostaDto>(cliente);
            clienteDto.PerfilTipo = cliente.Perfil.Nome;

            return clienteDto;
        }

        public async Task<ClienteRespostaDto> CriarAsync (ClienteCriacaoDto dto)
        {
            _logger.LogInformation("Criando cliente: {@Cliente}", dto);

            bool clienteExistente = await _clienteRepo.ExisteAsync(c => c.CPF == dto.CPF);
            if (clienteExistente)
            {
                _logger.LogWarning("Falha ao criar cliente: Cliente com CPF {CPF} já existe.", dto.CPF);
                throw new ArgumentException($"Cliente com CPF {dto.CPF} já existe.");
            }

            if (string.IsNullOrWhiteSpace(dto.Nome))
            {
                _logger.LogWarning("Falha ao criar cliente: Nome é obrigatório.");
                throw new ArgumentException("Nome do cliente é obrigatório.", nameof(dto.Nome));
            }

            if (dto.RendaMensal < 0)
            {
                _logger.LogWarning("Falha ao criar cliente: Renda mensal negativa.");
                throw new ArgumentException("Renda mensal não pode ser negativa.", nameof(dto.RendaMensal));
            }

            _senhaService.CriarSenhaHash(dto.Senha, out byte[] senhaHash, out byte[] senhaSalt);

            var cliente = _mapper.Map<Cliente>(dto);
            cliente.SenhaHash = senhaHash;
            cliente.SenhaSalt = senhaSalt;


            var perfil = _perfilRiscoService.AnalisarPerfil(cliente);

            cliente.Score = perfil.Score;
            cliente.PerfilId = await _perfilRiscoRepo.ObterPerfilIdPorNomeAsync(perfil.Nome);

            await _clienteRepo.AddAsync(cliente);

            _logger.LogInformation("Cliente criado com sucesso. ID: {Id}", cliente.Id);

            ClienteRespostaDto clienteRespostaDto = _mapper.Map<ClienteRespostaDto>(cliente);
            clienteRespostaDto.PerfilTipo = perfil.Nome;
            return clienteRespostaDto;
        }

        public async Task<ClienteRespostaDto> AtualizarAsync(int id, ClienteAtualizacaoDto dto)
        {
            _logger.LogInformation("Atualizando cliente ID {Id}", id);

            var existente = await _clienteRepo.ObterClienteComPerfil(id);

            if (existente is null)
            {
                _logger.LogWarning("Falha ao atualizar: Cliente ID {Id} não existe", id);
                throw new KeyNotFoundException($"Cliente com ID {id} não encontrado.");
            }

            bool precisaReanalisarPerfil = false;
            string? novoPerfilNome = null; // caso precisaReanalisarPerfil seja true

            if (dto.Nome is not null && dto.Nome != existente.Nome)
                existente.Nome = dto.Nome;

            if (dto.RendaMensal is not null && dto.RendaMensal != existente.RendaMensal)
                existente.RendaMensal = dto.RendaMensal.Value;

            if (dto.VolumeInvestimentos is not null && dto.VolumeInvestimentos != existente.VolumeInvestimentos)
            {
                existente.VolumeInvestimentos = dto.VolumeInvestimentos.Value;
                precisaReanalisarPerfil = true;
            }

            if (dto.FrequenciaMovimentacoes is not null && dto.FrequenciaMovimentacoes != existente.FrequenciaMovimentacoes)
            {
                existente.FrequenciaMovimentacoes = dto.FrequenciaMovimentacoes.Value;
                precisaReanalisarPerfil = true;
            }

            if (dto.PreferenciaLiquidez is not null && dto.PreferenciaLiquidez != existente.PreferenciaLiquidez)
            {
                existente.PreferenciaLiquidez = dto.PreferenciaLiquidez.Value;
                precisaReanalisarPerfil = true;
            }

            if (dto.PreferenciaRentabilidade is not null && dto.PreferenciaRentabilidade != existente.PreferenciaRentabilidade)
            {
                existente.PreferenciaRentabilidade = dto.PreferenciaRentabilidade.Value;
                precisaReanalisarPerfil = true;
            }

            if (precisaReanalisarPerfil)
            {
                var perfil = _perfilRiscoService.AnalisarPerfil(existente);
                existente.Score = perfil.Score;
                existente.PerfilId = await _perfilRiscoRepo.ObterPerfilIdPorNomeAsync(perfil.Nome);
                novoPerfilNome = perfil.Nome;
            }

            await _clienteRepo.UpdateAsync(existente);

            _logger.LogInformation("Cliente ID {Id} atualizado com sucesso", existente.Id);

            var dtoResposta = _mapper.Map<ClienteRespostaDto>(existente);
            dtoResposta.PerfilTipo = novoPerfilNome ?? existente.Perfil?.Nome;

            return dtoResposta;
        }

        public async Task RemoverAsync (int id)
        {
            _logger.LogInformation("Removendo cliente ID {Id}", id);

            var cliente = await _clienteRepo.ObterPorIdAsync(id);

            if (cliente is null)
            {
                _logger.LogWarning("Tentativa de remoção de cliente inexistente. ID {Id}", id);
                throw new KeyNotFoundException($"Cliente com ID {id} não encontrado.");
            }

            await _clienteRepo.RemoveAsync(cliente);

            _logger.LogInformation("Cliente ID {Id} removido com sucesso", id);
        }

    }
}
