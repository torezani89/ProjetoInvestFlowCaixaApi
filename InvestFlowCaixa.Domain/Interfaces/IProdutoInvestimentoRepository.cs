using InvestFlowCaixa.Domain.Entities;

namespace InvestFlowCaixa.Domain.Interfaces
{
    public interface IProdutoInvestimentoRepository : IRepository<ProdutoInvestimento>
    {
        Task<IEnumerable<ProdutoInvestimento>> GetByTipoAsync(string tipo);
        Task<IEnumerable<string>> GetTiposDisponiveisAsync();

    }
}
