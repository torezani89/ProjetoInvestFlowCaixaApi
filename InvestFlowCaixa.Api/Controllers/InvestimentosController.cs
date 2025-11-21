using InvestFlowCaixa.Application.HistoricoInvestimentos.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvestFlowCaixa.Api.Controllers
{
    [ApiController]
    [Route("api/investimentos")]
    public class InvestimentosController : ControllerBase
    {
        private readonly IHistoricoInvestimentoService _service;

        public InvestimentosController(IHistoricoInvestimentoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna o histórico de investimentos de um cliente específico.
        /// </summary>
        /// <response code="200">Retorna a lista de investimentos do cliente.</response>
        /// <response code="400">ClienteId inválido.</response>
        /// <response code="404">Nenhum histórico encontrado para o cliente informado.</response>
        /// <remarks>
        /// Exemplo de request:
        /// <pre>
        /// GET /api/investimentos/101
        /// </pre>
        ///
        /// Exemplo de resposta:
        /// <pre>
        /// [
        ///   {
        ///     "id": 1009,
        ///     "tipo": "Tesouro",
        ///     "valor": 200,
        ///     "rentabilidade": 0.112,
        ///     "data": "2025-03-15"
        ///   },
        ///   {
        ///     "id": 1006,
        ///     "tipo": "LCI",
        ///     "valor": 8000,
        ///     "rentabilidade": 0.101,
        ///     "data": "2025-03-12"
        ///   }
        /// ]
        /// </pre>
        /// Possíveis erros:
        /// - 400: "ClienteId inválido."  
        /// - 404: "Nenhum investimento encontrado para o cliente informado."  
        /// </remarks>
        [HttpGet("{clienteId}")]
        public async Task<IActionResult> GetHistorico(int clienteId)
        {
            if (clienteId <= 0)
                return BadRequest("ClienteId inválido.");

            var historico = await _service.ObterHistoricoAsync(clienteId);

            var response = historico.Select(h => new
            {
                id = h.Id,
                tipo = h.Tipo,
                valor = h.Valor,
                rentabilidade = h.Rentabilidade,
                data = h.Data.ToString("yyyy-MM-dd")
            });

            return Ok(response);
        }
    }
}
