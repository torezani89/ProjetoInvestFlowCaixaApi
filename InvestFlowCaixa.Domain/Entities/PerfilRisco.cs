using System.ComponentModel.DataAnnotations;

namespace InvestFlowCaixa.Domain.Entities
{
    public class PerfilRisco
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nome { get; set; } // Conservador, Moderado, Agressivo

        [Required]
        [MaxLength(300)]
        public string Descricao { get; set; }
    }
}
