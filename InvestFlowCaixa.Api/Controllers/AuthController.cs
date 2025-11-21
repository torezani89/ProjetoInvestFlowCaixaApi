using InvestFlowCaixa.Application.Authentication.Dtos;
using InvestFlowCaixa.Application.Authentication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestFlowCaixa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <remarks> Exemplo de request para "api/simular-investimento" com dados de cliente criado por seed para teste:
        /// <pre>
        /// {
        ///   "cpf": "11111111111",
        ///   "senha": "123"
        /// }
        /// </pre>
        /// Outros CPFs para teste: 22222222222, 33333333333. A senha também é 123.
        /// </remarks>
        [HttpPost("autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] AuthRequestDto dto)
        {
            var resultado = await _authService.AuthAsync(dto);
            return Ok(resultado);
        }
    }
}
