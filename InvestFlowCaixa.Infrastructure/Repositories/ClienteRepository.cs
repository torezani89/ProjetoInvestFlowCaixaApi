using InvestFlowCaixa.Domain.Entities;
using InvestFlowCaixa.Domain.Interfaces;
using InvestFlowCaixa.Infrastructure.Data;
using InvestFlowCaixa.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InvestFlowCaixa.Infrastructure.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(InvestimentosDbContext context) : base(context)
        {
        }

        public async Task<Cliente?> ObterClienteComPerfil(int id)
        {
            return await _dbSet
                .Include(c => c.Perfil)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cliente> ObterPorCpfAsync (string cpf)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.CPF == cpf);
        }

    }


}
