using InvestFlowCaixa.Application.Pagination;
using InvestFlowCaixa.Application.PerfilRisco.Services;
using InvestFlowCaixa.Application.ProdutosInvestimento.Services;
using InvestFlowCaixa.Application.Simulacoes.Dtos;
using InvestFlowCaixa.Domain.Entities;
using InvestFlowCaixa.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace InvestFlowCaixa.Application.Simulacoes.Services
{
    public class SimulacaoService : ISimulacaoService
    {
        private readonly ISimulacaoRepository _simRepo;
        private readonly IClienteRepository _clienteRepo;
        private readonly IProdutoInvestimentoRepository _produtoRepo;
        private readonly IProdutoInvestimentoService _produtoService;
        private readonly IPerfilRiscoService _perfilRiscoService;
        private readonly ILogger<SimulacaoService> _logger;

        public SimulacaoService(ISimulacaoRepository simRepo, IClienteRepository clienteRepo, IPerfilRiscoService perfilRiscoService,
            IProdutoInvestimentoRepository produtoRepo, IProdutoInvestimentoService produtoService, ILogger<SimulacaoService> logger)
        {
            _simRepo = simRepo;
            _clienteRepo = clienteRepo;
            _produtoRepo = produtoRepo;
            _produtoService = produtoService;
            _perfilRiscoService = perfilRiscoService;
            _logger = logger;
        }

        public async Task<SimulacaoResponseDto> SimularAsync(SimulacaoRequestDto request)
        {
            _logger.LogInformation("Iniciando simulação: {@Request}", request);

            if (request is null)
                throw new ArgumentException("Os dados da simulação não foram enviados.");

            if (request.ClienteId <= 0)
                throw new ArgumentException("ClienteId inválido.");

            if (request.Valor <= 0)
                throw new ArgumentException("O valor do investimento deve ser maior que zero.");

            if (request.PrazoMeses < 1)
                throw new ArgumentException("PrazoMeses deve ser pelo menos 1.");

            if (string.IsNullOrWhiteSpace(request.TipoProduto))
                throw new ArgumentException("TipoProduto é obrigatório.");

            var cliente = await _clienteRepo.ObterClienteComPerfil(request.ClienteId)
                         ?? throw new KeyNotFoundException($"Cliente com ID {request.ClienteId} não encontrado.");

            var perfilCliente = cliente.Perfil?.Nome
                               ?? throw new InvalidOperationException("Cliente não possui perfil cadastrado.");

            // obter produtos do tipo solicitado
            var produtosDoTipo = await _produtoService.ObterProdutosDoTipoAsync(request.TipoProduto);

            if (!produtosDoTipo.Any())
                throw new InvalidOperationException($"Nenhum produto do tipo '{request.TipoProduto}' foi encontrado.");

            // aplicar filtros por valor e prazo
            var elegiveis = _produtoService.FiltrarElegiveis(produtosDoTipo, request.Valor, request.PrazoMeses);

            if (!elegiveis.Any())
                throw new InvalidOperationException(
                    $"Nenhum produto do tipo '{request.TipoProduto}' é elegível " +
                    $"para valor {request.Valor} e prazo {request.PrazoMeses} meses."
                );

            // selecionar melhor produto
            var produtoSelecionado = _produtoService.SelecionarMelhorProduto(elegiveis, perfilCliente);

            // conversão de taxa anual → mensal
            decimal taxaMensal =
                (decimal)(Math.Pow(1 + (double)produtoSelecionado.Rentabilidade, 1.0 / 12.0) - 1);

            decimal valorFinal = Math.Round(
                request.Valor * (decimal)Math.Pow(1 + (double)taxaMensal, request.PrazoMeses), 2
            );

            var simulacaoEntity = new Simulacao
            {
                ClienteId = cliente.Id,
                ProdutoInvestimentoId = produtoSelecionado.Id,
                ValorInvestido = request.Valor,
                ValorFinal = valorFinal,
                PrazoMeses = request.PrazoMeses,
                RentabilidadeEfetiva = produtoSelecionado.Rentabilidade,
                DataSimulacao = DateTime.UtcNow
            };

            await _simRepo.AddAsync(simulacaoEntity);

            return new SimulacaoResponseDto
            {
                ClienteId = cliente.Id,
                ClienteNome = cliente.Nome,
                ProdutoValidado = new ProdutoValidadoDto
                {
                    Id = produtoSelecionado.Id,
                    Nome = produtoSelecionado.Nome,
                    Tipo = produtoSelecionado.Tipo,
                    Rentabilidade = produtoSelecionado.Rentabilidade,
                    Risco = produtoSelecionado.Risco
                },
                ResultadoSimulacao = new ResultadoSimulacaoDto
                {
                    ValorInvestido = request.Valor.ToString("F2", CultureInfo.InvariantCulture),
                    ValorFinal = valorFinal.ToString("F2", CultureInfo.InvariantCulture),
                    RentabilidadeEfetiva = produtoSelecionado.Rentabilidade,
                    PrazoMeses = request.PrazoMeses
                },
                DataSimulacao = simulacaoEntity.DataSimulacao
            };
        }

        public async Task<SimulacaoResponseDto> ObterPorIdAsync (int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID inválido.");

            var sim = await _simRepo.ObterUmComClientesEProduto(id)
                      ?? throw new KeyNotFoundException($"Simulação com ID {id} não encontrada.");

            return new SimulacaoResponseDto
            {
                ClienteId = sim.ClienteId,
                ClienteNome = sim.Cliente?.Nome ?? "(desconhecido)",
                ProdutoValidado = new ProdutoValidadoDto
                {
                    Id = sim.ProdutoInvestimento.Id,
                    Nome = sim.ProdutoInvestimento.Nome,
                    Tipo = sim.ProdutoInvestimento.Tipo,
                    Rentabilidade = sim.ProdutoInvestimento.Rentabilidade,
                    Risco = sim.ProdutoInvestimento.Risco
                },
                ResultadoSimulacao = new ResultadoSimulacaoDto
                {
                    ValorInvestido = sim.ValorInvestido.ToString("F2", CultureInfo.InvariantCulture),
                    ValorFinal = sim.ValorFinal.ToString("F2", CultureInfo.InvariantCulture),
                    RentabilidadeEfetiva = sim.RentabilidadeEfetiva,
                    PrazoMeses = sim.PrazoMeses
                },
                DataSimulacao = sim.DataSimulacao
            };
        }

        public async Task<PaginacaoResultadoDto<SimulacaoListItemDto>> ListarSimulacoesAsync (int page, int pageSize)
        {
            if (page < 1)
                throw new ArgumentException("O número da página deve ser maior ou igual a 1.");

            if (pageSize < 1)
                throw new ArgumentException("O tamanho da página deve ser maior ou igual a 1.");

            var (dados, total) = await _simRepo.ObterListaComPaginacao(page, pageSize);

            var lista = dados
                .OrderByDescending(s => s.DataSimulacao)
                .Select(s => new SimulacaoListItemDto
                {
                    Id = s.Id,
                    ClienteId = s.ClienteId,
                    Produto = s.ProdutoInvestimento.Nome,
                    ValorInvestido = s.ValorInvestido.ToString("F2", CultureInfo.InvariantCulture),
                    ValorFinal = s.ValorFinal.ToString("F2", CultureInfo.InvariantCulture),
                    PrazoMeses = s.PrazoMeses,
                    RentabilidadeEfetiva = s.RentabilidadeEfetiva,
                    DataSimulacao = s.DataSimulacao
                });

            return new PaginacaoResultadoDto<SimulacaoListItemDto>
            {
                PaginaAtual = page,
                TamanhoPagina = pageSize,
                TotalRegistros = total,
                TotalPaginas = (int)Math.Ceiling(total / (double)pageSize),
                Dados = lista
            };
        }

        public async Task<IEnumerable<SimulacaoPorProdutoDiaDto>> ObterSimulacoesPorProdutoDiaAsync()
        {
            var sims = await _simRepo.ObterListaComClientesEProduto();

            return sims
                .GroupBy(s => new { Produto = s.ProdutoInvestimento.Nome, Dia = s.DataSimulacao.Date })
                .Select(g => new SimulacaoPorProdutoDiaDto
                {
                    Produto = g.Key.Produto,
                    Data = g.Key.Dia,
                    QuantidadeSimulacoes = g.Count(),
                    MediaValorFinal = g.Average(x => x.ValorFinal)
                })
                .OrderBy(x => x.Data)
                .ThenBy(x => x.Produto)
                .ToList();
        }

    }
}
