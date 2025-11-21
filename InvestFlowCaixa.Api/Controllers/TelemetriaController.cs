using InvestFlowCaixa.Application.Telemetria.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace InvestFlowCaixa.Api.Controllers
{
    [ApiController]
    [Route("api/telemetria")]
    public class TelemetriaController : ControllerBase
    {
        private readonly ITelemetriaService _service;

        public TelemetriaController(ITelemetriaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna os dados de telemetria dos serviços para as rotas "perfil-risco" e "simular-investimento".
        /// </summary>
        /// <response code="200">
        /// Retorna o conjunto de métricas registradas, incluindo quantidade de chamadas, tempo médio de resposta e período analisado.
        /// </response>
        /// <remarks>
        /// Exemplo de resposta:
        /// <pre>
        /// {
        ///   "servicos": [
        ///     {
        ///       "nome": "perfil-risco",
        ///       "quantidadeChamadas": 62,
        ///       "mediaTempoRespostaMs": 66
        ///     },
        ///     {
        ///       "nome": "simular-investimento",
        ///       "quantidadeChamadas": 27,
        ///       "mediaTempoRespostaMs": 1086
        ///     }
        ///   ],
        ///   "periodo": {
        ///     "inicio": "2025-10-01T00:00:00",
        ///     "fim": "2025-11-21T00:00:00-03:00"
        ///   }
        /// }
        /// </pre>
        /// </remarks>
        [HttpGet]
        public async Task<IActionResult> Obter()
        {
            var result = await _service.ObterTelemetriaAsync();
            return Ok(result);
        }
    }

}
