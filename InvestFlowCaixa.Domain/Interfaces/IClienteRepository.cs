using InvestFlowCaixa.Domain.Entities;
using System.Linq.Expressions;

namespace InvestFlowCaixa.Domain.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> ObterPorCpfAsync(string cpf);
        Task<Cliente?> ObterClienteComPerfil(int id);
    }
}
