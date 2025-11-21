using InvestFlowCaixa.Domain.Entities;

namespace InvestFlowCaixa.Domain.Interfaces
{
    public interface IPerfilRiscoRepository : IRepository<PerfilRisco>
    {
        Task<int> ObterPerfilIdPorNomeAsync(string nomePerfil);
    }
}
