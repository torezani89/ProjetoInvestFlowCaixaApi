using System.ComponentModel.DataAnnotations;

namespace InvestFlowCaixa.Domain.Entities
{
    public class ProdutoInvestimento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Tipo { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Rentabilidade { get; set; }

        [Required]
        [MaxLength(20)]
        public string Risco { get; set; }

        [MaxLength(20)]
        public string Liquidez { get; set; }

        public decimal MinValor { get; set; }
        public int MaxPrazoMeses { get; set; }
    }
}
