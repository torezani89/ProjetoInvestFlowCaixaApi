using InvestFlowCaixa.Application.HistoricoInvestimentos.Services;
using InvestFlowCaixa.Domain.Entities;
using InvestFlowCaixa.Domain.Interfaces;

namespace InvestFlowCaixa.Application.Historicos.Services
{
    public class HistoricoInvestimentoService : IHistoricoInvestimentoService
    {
        private readonly IHistoricoInvestimentoRepository _repo;

        public HistoricoInvestimentoService(IHistoricoInvestimentoRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<HistoricoInvestimento>> ObterHistoricoAsync(int clienteId)
        {
            return await _repo.ObterPorClienteAsync(clienteId);
        }
    }
}
