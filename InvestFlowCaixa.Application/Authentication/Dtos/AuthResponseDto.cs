using InvestFlowCaixa.Application.Clientes.Dtos;

namespace InvestFlowCaixa.Application.Authentication.Dtos
{
    public class AuthResponseDto
    {
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public TokenResponseDto Token { get; set; }
    }
}
