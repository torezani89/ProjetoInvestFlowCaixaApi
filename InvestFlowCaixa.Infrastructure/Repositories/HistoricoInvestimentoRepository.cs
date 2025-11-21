using InvestFlowCaixa.Domain.Entities;
using InvestFlowCaixa.Domain.Interfaces;
using InvestFlowCaixa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InvestFlowCaixa.Infrastructure.Repositories
{
    public class HistoricoInvestimentoRepository : IHistoricoInvestimentoRepository
    {
        private readonly InvestimentosDbContext _context;

        public HistoricoInvestimentoRepository(InvestimentosDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HistoricoInvestimento>> ObterPorClienteAsync(int clienteId)
        {
            return await _context.HistoricoInvestimentos
                .Where(h => h.ClienteId == clienteId)
                .OrderByDescending(h => h.Data)
                .ToListAsync();
        }
    }
}
