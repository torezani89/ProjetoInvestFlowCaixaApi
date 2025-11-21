using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestFlowCaixa.Domain.Entities
{
    public class Simulacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [Required]
        public int ProdutoInvestimentoId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; }

        [ForeignKey(nameof(ProdutoInvestimentoId))]
        public ProdutoInvestimento ProdutoInvestimento { get; set; }

        [Range(0, double.MaxValue)]
        public decimal ValorInvestido { get; set; }

        [Range(0, double.MaxValue)]
        public decimal ValorFinal { get; set; }

        [Range(1, 360)]
        public int PrazoMeses { get; set; }

        public decimal RentabilidadeEfetiva { get; set; }

        [Required]
        public DateTime DataSimulacao { get; set; }
    }
}
