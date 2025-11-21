using InvestFlowCaixa.Application.Clientes.Dtos;
using InvestFlowCaixa.Domain.Entities;

namespace InvestFlowCaixa.Application.Clientes.Services
{
    public interface ITokenService
    {
        TokenResponseDto CriarToken(Cliente cliente);
    }
}
