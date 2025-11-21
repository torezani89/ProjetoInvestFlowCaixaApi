using Azure.Core;
using InvestFlowCaixa.Domain.Entities;
using InvestFlowCaixa.Domain.Interfaces;
using InvestFlowCaixa.Infrastructure.Data;
using InvestFlowCaixa.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace InvestFlowCaixa.Infrastructure.Repositories
{
    public class ProdutoInvestimentoRepository
        : Repository<ProdutoInvestimento>, IProdutoInvestimentoRepository
    {
        public ProdutoInvestimentoRepository(InvestimentosDbContext context)
            : base(context)
        {
        }

        //var produtosDoTipo = await _produtoRepo.GetByTipoAsync(request.TipoProduto);
        public async Task<IEnumerable<ProdutoInvestimento>> GetByTipoAsync(string tipo)
        {
            return await _context.ProdutosInvestimento
                .Where(p => p.Tipo.ToLower() == tipo.ToLower())
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetTiposDisponiveisAsync()
        {
            return await _context.ProdutosInvestimento
                .Select(p => p.Tipo)
                .Distinct()
                .ToListAsync();
        }

    }
}
