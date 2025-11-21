using System.ComponentModel.DataAnnotations;

namespace InvestFlowCaixa.Application.Clientes.Dtos
{
    public class ClienteAtualizacaoDto
    {
        [MaxLength(150)]
        public string? Nome { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? RendaMensal { get; set; }

        [Range(0, int.MaxValue)]
        public decimal? VolumeInvestimentos { get; set; }

        [Range(0, int.MaxValue)]
        public int? FrequenciaMovimentacoes { get; set; }

        [Range(1, 10, ErrorMessage = "Informe um valor entre 1 e 10")]
        public int? PreferenciaLiquidez { get; set; }

        [Range(1, 10, ErrorMessage = "Informe um valor entre 1 e 10")]
        public int? PreferenciaRentabilidade { get; set; }
    }
}
