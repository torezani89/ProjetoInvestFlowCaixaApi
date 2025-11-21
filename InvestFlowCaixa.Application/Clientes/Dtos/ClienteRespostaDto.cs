using System.ComponentModel.DataAnnotations;

namespace InvestFlowCaixa.Application.Clientes.Dtos
{
    public class ClienteRespostaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public decimal RendaMensal { get; set; }
        public decimal VolumeInvestimentos { get; set; }
        public int FrequenciaMovimentacoes { get; set; }
        public int PreferenciaLiquidez { get; set; }
        public int PreferenciaRentabilidade { get; set; }
        public int Score { get; set; }
        public string PerfilTipo { get; set; }
    }
}
