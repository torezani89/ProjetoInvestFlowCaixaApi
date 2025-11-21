using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvestFlowCaixa.Domain.Entities
{
    public class HistoricoInvestimento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; }

        [Required]
        [MaxLength(50)]
        public string Tipo { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Valor { get; set; }

        public decimal Rentabilidade { get; set; }

        [Required]
        public DateTime Data { get; set; }
    }
}
