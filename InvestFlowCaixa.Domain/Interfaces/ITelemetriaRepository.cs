using InvestFlowCaixa.Domain.Entities;

namespace InvestFlowCaixa.Domain.Interfaces
{
    public interface ITelemetriaRepository
    {
        Task<List<TelemetriaServico>> ObterPorPeriodoAsync(DateTime inicio, DateTime fim);
    }

}
