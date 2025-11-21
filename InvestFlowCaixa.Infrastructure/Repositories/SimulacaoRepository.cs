using InvestFlowCaixa.Domain.Entities;
using InvestFlowCaixa.Domain.Interfaces;
using InvestFlowCaixa.Infrastructure.Data;
using InvestFlowCaixa.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace InvestFlowCaixa.Infrastructure.Repositories
{
    public class SimulacaoRepository : Repository<Simulacao>, ISimulacaoRepository
    {
        public SimulacaoRepository(InvestimentosDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Simulacao>> ObterListaComClientesEProduto()
        {
            return await _dbSet
                .Include(s => s.Cliente)
                .Include(s => s.ProdutoInvestimento)
                .ToListAsync();
        }

        public async Task<Simulacao?> ObterUmComClientesEProduto(int id)
        {
            return await _dbSet
                .Include(s => s.Cliente)
                .Include(s => s.ProdutoInvestimento)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<(IEnumerable<Simulacao> Dados, int TotalRegistros)> ObterListaComPaginacao (int page, int pageSize)
        {
            var query = _context.Simulacoes
                .Include(s => s.Cliente)
                .Include(s => s.ProdutoInvestimento)
                .AsNoTracking();

            int totalRegistros = await query.CountAsync();

            var dados = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (dados, totalRegistros);
        }

    }
}
