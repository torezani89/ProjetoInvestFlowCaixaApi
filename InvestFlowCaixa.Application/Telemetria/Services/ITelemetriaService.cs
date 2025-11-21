
using InvestFlowCaixa.Application.Telemetria.Dtos;

namespace InvestFlowCaixa.Application.Telemetria.Services
{
    public interface ITelemetriaService
    {
        Task<TelemetriaRespostaDto> ObterTelemetriaAsync();
    }
}
