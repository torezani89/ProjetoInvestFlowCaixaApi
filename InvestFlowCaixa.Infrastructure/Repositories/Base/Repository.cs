using InvestFlowCaixa.Domain.Interfaces;
using InvestFlowCaixa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InvestFlowCaixa.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly InvestimentosDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(InvestimentosDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T?> ObterPorIdAsync(int id)
            => await _dbSet.FindAsync(id);

        public virtual async Task<IEnumerable<T>> ObterTodosAsync()
            => await _dbSet.ToListAsync();

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            //_dbSet.Update(entity); objeto já vem rastreado do service.
            await _context.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExisteAsync (Expression<Func<T, bool>> predicate)
            => await _dbSet.AnyAsync(predicate);

    }

}
