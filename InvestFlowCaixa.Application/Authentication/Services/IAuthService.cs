
using InvestFlowCaixa.Application.Authentication.Dtos;

namespace InvestFlowCaixa.Application.Authentication.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> AuthAsync(AuthRequestDto dto);
    }
}
