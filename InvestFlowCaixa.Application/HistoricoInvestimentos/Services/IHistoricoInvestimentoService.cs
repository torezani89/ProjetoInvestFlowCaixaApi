using InvestFlowCaixa.Domain.Entities;

namespace InvestFlowCaixa.Application.HistoricoInvestimentos.Services
{
    public interface IHistoricoInvestimentoService
    {
        Task<IEnumerable<HistoricoInvestimento>> ObterHistoricoAsync(int clienteId);
    }

}
