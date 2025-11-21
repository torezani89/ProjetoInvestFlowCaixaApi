using InvestFlowCaixa.Domain.Entities;

namespace InvestFlowCaixa.Application.ProdutosInvestimento.Services
{
    public interface IProdutoInvestimentoService
    {
        Task<IEnumerable<ProdutoInvestimento>> ObterProdutosDoTipoAsync(string tipo);
        List<string> ObterRiscosPermitidos(string perfilCliente);
        List<ProdutoInvestimento> FiltrarElegiveis(IEnumerable<ProdutoInvestimento> produtos, decimal valor, int prazoMeses);
        ProdutoInvestimento SelecionarMelhorProduto(List<ProdutoInvestimento> elegiveis, string perfilCliente);
        Task<IEnumerable<ProdutoInvestimento>> ObterProdutosRecomendadosPorPerfilAsync(int perfilId);
    }
}
