using System.ComponentModel.DataAnnotations;

namespace InvestFlowCaixa.Application.Clientes.Dtos
{
    public class ClienteCriacaoDto
    {
        [Required(ErrorMessage = "Digite o nome")]
        [MaxLength(150)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o CPF")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter exatamente 11 dígitos numéricos.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Digite a renda mensal")]
        [Range(0, double.MaxValue)]
        public decimal RendaMensal { get; set; }

        [Required(ErrorMessage = "Digite o volume de investimentos")]
        [Range(0, int.MaxValue)]
        public decimal VolumeInvestimentos { get; set; }

        [Required(ErrorMessage = "Digite a frequência de movimentações")]
        [Range(0, int.MaxValue)]
        public int FrequenciaMovimentacoes { get; set; }

        [Required(ErrorMessage = "Digite a preferência por liquidez de 1 a 10")]
        [Range(1, 10, ErrorMessage = "Informe um valor entre 1 e 10")]
        public int PreferenciaLiquidez { get; set; }

        [Required(ErrorMessage = "Digite a preferência por rentabilidade de 1 a 10")]
        [Range(1, 10, ErrorMessage = "Informe um valor entre 1 e 10")]
        public int PreferenciaRentabilidade { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; } = string.Empty;


        [Required(ErrorMessage = "Digite a confirmação de senha")]
        [Compare("Senha", ErrorMessage = "As senhas não conferem")]
        public string ConfirmaSenha { get; set; } = string.Empty;
    }
}
