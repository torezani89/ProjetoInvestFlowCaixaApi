using InvestFlowCaixa.Domain.Entities;

namespace InvestFlowCaixa.Domain.Interfaces
{
    public interface ISimulacaoRepository : IRepository<Simulacao>
    {
        Task<(IEnumerable<Simulacao> Dados, int TotalRegistros)> ObterListaComPaginacao(int page, int pageSize);
        Task<IEnumerable<Simulacao>> ObterListaComClientesEProduto();
        Task<Simulacao?> ObterUmComClientesEProduto(int id);
    }
}
