using System;
using System.ComponentModel.DataAnnotations;

namespace InvestFlowCaixa.Domain.Entities
{
    public class TelemetriaServico
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string NomeServico { get; set; } // "simular-investimento", "perfil-risco"

        [Range(0, int.MaxValue)]
        public int QuantidadeChamadas { get; set; }

        [Range(0, int.MaxValue)]
        public int TempoMedioRespostaMs { get; set; }

        public DateTime DataReferencia { get; set; }
    }
}
