using InvestFlowCaixa.Domain.Entities;

namespace InvestFlowCaixa.Domain.Interfaces
{
    public interface IHistoricoInvestimentoRepository
    {
        Task<IEnumerable<HistoricoInvestimento>> ObterPorClienteAsync(int clienteId);
    }

}
