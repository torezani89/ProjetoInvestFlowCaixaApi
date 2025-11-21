using InvestFlowCaixa.Domain.Entities;
using System.Linq.Expressions;

namespace InvestFlowCaixa.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> ObterPorIdAsync(int id);
        Task<IEnumerable<T>> ObterTodosAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task<bool> ExisteAsync(Expression<Func<T, bool>> predicate);
    }

}
