using InvestFlowCaixa.Application.Pagination;
using InvestFlowCaixa.Application.Simulacoes.Dtos;

namespace InvestFlowCaixa.Application.Simulacoes.Services
{
    public interface ISimulacaoService
    {
        Task<SimulacaoResponseDto> SimularAsync(SimulacaoRequestDto request);
        Task<SimulacaoResponseDto> ObterPorIdAsync(int id);
        Task<PaginacaoResultadoDto<SimulacaoListItemDto>> ListarSimulacoesAsync(int page, int pageSize);
        Task<IEnumerable<SimulacaoPorProdutoDiaDto>> ObterSimulacoesPorProdutoDiaAsync();
    }
}
