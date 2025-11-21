
namespace InvestFlowCaixa.Application.Simulacoes.Dtos
{
    public class ProdutoValidadoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public decimal Rentabilidade { get; set; }
        public string Risco { get; set; } = string.Empty;
    }

    public class ResultadoSimulacaoDto
    {
        public string ValorInvestido { get; set; }
        public string ValorFinal { get; set; }
        public decimal RentabilidadeEfetiva { get; set; }
        public int PrazoMeses { get; set; }
    }

    public class SimulacaoResponseDto
    {
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; } = string.Empty;
        public ProdutoValidadoDto ProdutoValidado { get; set; } = new ProdutoValidadoDto();
        public ResultadoSimulacaoDto ResultadoSimulacao { get; set; } = new ResultadoSimulacaoDto();
        public DateTime DataSimulacao { get; set; }
    }
}
