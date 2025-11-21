namespace InvestFlowCaixa.Application.Pagination
{
    public class PaginacaoResultadoDto<T>
    {
        public int PaginaAtual { get; set; }
        public int TamanhoPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public IEnumerable<T> Dados { get; set; } = new List<T>();
    }
}
