using AutoMapper;
using InvestFlowCaixa.Application.Authentication.Dtos;
using InvestFlowCaixa.Application.Clientes.Services;
using InvestFlowCaixa.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace InvestFlowCaixa.Application.Authentication.Services
{
    public class AuthService : IAuthService
    {
        private readonly IClienteRepository _clienteRepo;
        private readonly ISenhaService _senhaService;
        private readonly ITokenService _tokenService;
        private readonly ILogger<ClienteService> _logger;

        public AuthService(IClienteRepository repository, ILogger<ClienteService> logger, 
            IMapper mapper, ISenhaService senhaService, ITokenService tokenService)
        {
            _clienteRepo = repository;
            _logger = logger;
            _senhaService = senhaService;
            _tokenService = tokenService;
        }

        public async Task<AuthResponseDto> AuthAsync(AuthRequestDto dto)
        {
            _logger.LogInformation("Tentativa de login para o CPF: {CPF}", dto.CPF);

            var cliente = await _clienteRepo.ObterPorCpfAsync(dto.CPF);

            if (cliente == null)
            {
                _logger.LogWarning("Cliente não encontrado para o CPF: {CPF}", dto.CPF);
                throw new KeyNotFoundException("Cliente não localizado");
            }

            bool senhaValida = _senhaService.VerificarSenhaHash(dto.Senha, cliente.SenhaHash, cliente.SenhaSalt);
            if (!senhaValida)
            {
                _logger.LogWarning("Senha inválida para o CPF: {CPF}", dto.CPF);
                throw new UnauthorizedAccessException("Senha inválida");
            }

            var token = _tokenService.CriarToken(cliente);
            cliente.Token = token.Token;

            await _clienteRepo.UpdateAsync(cliente);

            _logger.LogInformation("Login realizado com sucesso para o usuário: {UsuarioId}", cliente.Id);

            return new AuthResponseDto
            {
                ClienteId = cliente.Id,
                ClienteNome = cliente.Nome,
                Token = token
            };
        }
    }
}
