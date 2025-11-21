
namespace InvestFlowCaixa.Application.Telemetria.Dtos
{
    public class TelemetriaRespostaDto
    {
        public List<TelemetriaServicoDto> Servicos { get; set; }
        public TelemetriaPeriodoDto Periodo { get; set; }
    }
}
