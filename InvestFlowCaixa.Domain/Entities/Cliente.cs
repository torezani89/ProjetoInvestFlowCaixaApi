using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvestFlowCaixa.Domain.Entities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"^\d{11}$")]
        public string CPF { get; set; }

        [Range(0, double.MaxValue)]
        public decimal RendaMensal { get; set; }

        // Dados para análise de perfil de risco
        [Range(0, int.MaxValue)]
        public decimal VolumeInvestimentos { get; set; }

        [Range(0, int.MaxValue)]
        public int FrequenciaMovimentacoes { get; set; }

        [Range(1, 10)]
        public int PreferenciaLiquidez { get; set; }

        [Range(1, 10)]
        public int PreferenciaRentabilidade { get; set; }

        [Range(0, 100)]
        public int Score { get; set; }
        public int PerfilId { get; set; }

        public string Token { get; set; } = string.Empty;
        public byte[] SenhaHash { get; set; } = new byte[0];
        public byte[] SenhaSalt { get; set; } = new byte[0];

        public PerfilRisco Perfil { get; set; } // Navegação

        // Relacionamentos
        public ICollection<Simulacao> Simulacoes { get; set; }
        public ICollection<HistoricoInvestimento> Historico { get; set; }
    }
}
