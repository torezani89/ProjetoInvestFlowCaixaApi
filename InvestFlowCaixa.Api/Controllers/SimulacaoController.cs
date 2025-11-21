using InvestFlowCaixa.Application.Simulacoes.Dtos;
using InvestFlowCaixa.Application.Simulacoes.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InvestFlowCaixa.Api.Controllers
{
    [ApiController]
    [Route("simular-investimento")]
    public class SimulacaoController : ControllerBase
    {
        private readonly ISimulacaoService _simulacaoService;
        private readonly ILogger<SimulacaoController> _logger;

        public SimulacaoController(ISimulacaoService simulacaoService, ILogger<SimulacaoController> logger)
        {
            _simulacaoService = simulacaoService;
            _logger = logger;
        }

        /// <summary>
        /// Realiza uma simulação de investimento.
        /// </summary>
        /// <response code="200">Retorna o resultado da simulação.</response>
        /// <response code="400">Erro de validação nos dados da simulação.</response>
        /// <remarks>
        /// Exemplo de request:
        /// <pre>
        /// {
        ///   "clienteId": 1,
        ///   "valor": 10000,
        ///   "prazoMeses": 12,
        ///   "tipoProduto": "CDB"
        /// }
        /// </pre>
        ///
        /// Exemplo de resposta:
        /// <pre>
        /// {
        ///   "clienteId": 1,
        ///   "clienteNome": "Cesar Viana",
        ///   "produtoValidado": {
        ///     "id": 3,
        ///     "nome": "CDB 12 meses",
        ///     "tipo": "CDB",
        ///     "rentabilidade": 0.12,
        ///     "risco": "Baixo"
        ///   },
        ///   "resultadoSimulacao": {
        ///     "valorInvestido": "10000",
        ///     "valorFinal": "11200",
        ///     "rentabilidadeEfetiva": 0.12,
        ///     "prazoMeses": 12
        ///   },
        ///   "dataSimulacao": "2025-11-21T10:55:00"
        /// }
        /// </pre>
        ///
        /// Possíveis erros:
        /// - 400: "Cliente não encontrado."  
        /// - 400: "Produto inválido para o perfil do cliente."  
        /// - 400: "Valor deve ser maior que zero."  
        /// </remarks>
        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> Simular([FromBody] SimulacaoRequestDto dto)
        {
            _logger.LogInformation(
                "Recebido POST /simular-investimento | ClienteId={ClienteId} Valor={Valor} Prazo={PrazoMeses} TipoProduto={TipoProduto}",
                dto?.ClienteId, dto?.Valor, dto?.PrazoMeses, dto?.TipoProduto
            );

            var result = await _simulacaoService.SimularAsync(dto);
            return Ok(result);
        }

        /// <summary>
        /// Retorna os detalhes de uma simulação específica.
        /// </summary>
        /// <response code="200">Retorna os detalhes da simulação.</response>
        /// <response code="404">Simulação não encontrada.</response>
        /// <remarks>
        /// Exemplo de resposta:
        /// <pre>
        /// {
        ///   "clienteId": 1,
        ///   "clienteNome": "Cesar Viana",
        ///   "produtoValidado": {
        ///     "id": 3,
        ///     "nome": "CDB 12 meses",
        ///     "tipo": "CDB",
        ///     "rentabilidade": 0.12,
        ///     "risco": "Baixo"
        ///   },
        ///   "resultadoSimulacao": {
        ///     "valorInvestido": "10000",
        ///     "valorFinal": "11200",
        ///     "rentabilidadeEfetiva": 0.12,
        ///     "prazoMeses": 12
        ///   },
        ///   "dataSimulacao": "2025-11-21T10:55:00"
        /// }
        /// </pre>
        /// </remarks>
        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterDetalhes(int id)
        {
            _logger.LogInformation("GET /simular-investimento/{Id} — buscando detalhes da simulação.", id);

            var result = await _simulacaoService.ObterPorIdAsync(id);

            return Ok(result);
        }


        /// <summary>
        /// Retorna a lista paginada de simulações realizadas.
        /// </summary>
        /// <response code="200">Lista paginada de simulações.</response>
        /// <remarks>
        /// Exemplo de resposta:
        /// <pre>
        /// {
        ///   "paginaAtual": 1,
        ///   "totalPaginas": 5,
        ///   "totalRegistros": 42,
        ///   "registros": [
        ///     {
        ///       "clienteId": 1,
        ///       "clienteNome": "Cesar Viana",
        ///       "dataSimulacao": "2025-11-20T14:20:00",
        ///       "produtoValidado": { ... },
        ///       "resultadoSimulacao": { ... }
        ///     }
        ///   ]
        /// }
        /// </pre>
        /// </remarks>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Listar([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            _logger.LogInformation("GET /simular-investimento — listando todas as simulações.");

            var result = await _simulacaoService.ListarSimulacoesAsync(page, pageSize);

            return Ok(result);
        }

        /// <summary>
        /// Retorna a quantidade de simulações agrupada por produto e dia.
        /// </summary>
        /// <response code="200">Retorna o agrupamento de simulações por produto e data.</response>
        /// <remarks>
        /// Exemplo de resposta:
        /// <pre>
        /// [
        ///   {
        ///     "data": "2025-11-20",
        ///     "produto": "CDB",
        ///     "quantidade": 12
        ///   },
        ///   {
        ///     "data": "2025-11-20",
        ///     "produto": "LCI",
        ///     "quantidade": 5
        ///   }
        /// ]
        /// </pre>
        /// </remarks>
        [HttpGet("por-produto-dia")]
        public async Task<IActionResult> ObterSimulacoesPorProdutoDia()
        {
            var result = await _simulacaoService.ObterSimulacoesPorProdutoDiaAsync();
            return Ok(result);
        }

    }
}
