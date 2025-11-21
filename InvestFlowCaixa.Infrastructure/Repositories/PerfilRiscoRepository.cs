
using InvestFlowCaixa.Domain.Entities;
using InvestFlowCaixa.Domain.Interfaces;
using InvestFlowCaixa.Infrastructure.Data;
using InvestFlowCaixa.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace InvestFlowCaixa.Infrastructure.Repositories
{
    public class PerfilRiscoRepository : Repository<PerfilRisco>, IPerfilRiscoRepository
    {
        public PerfilRiscoRepository(InvestimentosDbContext context) : base(context)
        {
        }

        public async Task<int> ObterPerfilIdPorNomeAsync(string nomePerfil)
        {
            return await _context.PerfisRisco
                .Where(p => p.Nome == nomePerfil)
                .Select(p => p.Id)
                .FirstAsync();
        }
    }
}
