using System.ComponentModel.DataAnnotations;

namespace InvestFlowCaixa.Application.Authentication.Dtos
{
    public class AuthRequestDto
    {
        [Required(ErrorMessage = "Digite o CPF")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }
    }
}
