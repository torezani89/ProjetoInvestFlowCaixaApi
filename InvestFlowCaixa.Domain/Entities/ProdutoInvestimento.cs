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
        public string Tipo { get; set; } // Ex: "CDB", "LCI", "Tesouro"

        [Range(0, double.MaxValue)]
        public decimal Rentabilidade { get; set; } // Ex: 0.12

        [Required]
        [MaxLength(20)]
        public string Risco { get; set; } // "Baixo", "Moderado", "Alto"

        [MaxLength(20)]
        public string Liquidez { get; set; } // Ex: "D+1"

        public decimal MinValor { get; set; }
        public int MaxPrazoMeses { get; set; }
    }
}
