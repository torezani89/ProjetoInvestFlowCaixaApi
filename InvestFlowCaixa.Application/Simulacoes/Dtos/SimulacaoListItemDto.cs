using System.Text.Json.Serialization;

namespace InvestFlowCaixa.Application.Simulacoes.Dtos
{
    public class SimulacaoListItemDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Produto { get; set; }
        public string ValorInvestido { get; set; }
        public string ValorFinal { get; set; }
        public int PrazoMeses { get; set; }
        public decimal RentabilidadeEfetiva { get; set; }
        public DateTime DataSimulacao { get; set; }
    }
}
    //{
    //    public int Id { get; set; }
    //    public int ClienteId { get; set; }
    //    public string ClienteNome { get; set; } = string.Empty;

    //    public ProdutoValidadoDto Produto { get; set; } = new ProdutoValidadoDto();

    //    public decimal ValorInvestido { get; set; }
    //    public decimal ValorFinal { get; set; }
    //    public int PrazoMeses { get; set; }
    //    public decimal RentabilidadeEfetiva { get; set; }

    //    public DateTime DataSimulacao { get; set; }
    //}
