using InvestFlowCaixa.Domain.Entities;
using InvestFlowCaixa.Domain.Interfaces;
using InvestFlowCaixa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InvestFlowCaixa.Infrastructure.Repositories
{
    public class TelemetriaRepository : ITelemetriaRepository
    {
        private readonly InvestimentosDbContext _context;

        public TelemetriaRepository(InvestimentosDbContext context)
        {
            _context = context;
        }

        public async Task<List<TelemetriaServico>> ObterPorPeriodoAsync(DateTime inicio, DateTime fim)
        {
            return await _context.TelemetriaServicos
                .Where(t => t.DataReferencia >= inicio && t.DataReferencia <= fim)
                .AsNoTracking()
                .ToListAsync();
        }
    }

}
