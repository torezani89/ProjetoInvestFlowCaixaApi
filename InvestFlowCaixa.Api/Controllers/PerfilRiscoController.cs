using InvestFlowCaixa.Application.PerfilRisco.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvestFlowCaixa.Api.Controllers
{
    [ApiController]
    [Route("api/perfil-risco")]
    public class PerfilRiscoController : ControllerBase
    {
        private readonly IPerfilRiscoService _perfilService;

        public PerfilRiscoController(IPerfilRiscoService perfilService)
        {
            _perfilService = perfilService;
        }

        /// <summary>
        /// Retorna o perfil de risco de um cliente específico.
        /// </summary>
        /// <response code="200">Perfil de risco retornado com sucesso.</response>
        /// <response code="400">ClienteId inválido.</response>
        /// <response code="404">Cliente não encontrado.</response>
        /// <response code="409">Cliente encontrado, porém sem perfil associado.</response>
        /// <remarks>
        /// Exemplo de request:
        /// <pre>
        /// GET /api/perfil-risco/101
        /// </pre>
        /// Exemplo de resposta:
        /// <pre>
        /// {
        ///   "clienteId": 14,
        ///   "perfil": "Conservador",
        ///   "pontuacao": 23,
        ///   "descricao": "Baixa movimentação e foco em liquidez."
        /// }
        /// </pre>
        /// Possíveis erros: <br />
        /// - 400: "ClienteId inválido." <br />
        /// - 404: "Cliente ID X não encontrado." <br />
        /// - 409: "Cliente ID X não possui perfil associado." <br />
        /// </remarks>
        [HttpGet("{clienteId}")]
        public async Task<IActionResult> Obter(int clienteId)
        {
            var result = await _perfilService.ObterPerfilAsync(clienteId);

            return Ok(result);
        }
    }

}
