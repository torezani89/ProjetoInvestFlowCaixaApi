using InvestFlowCaixa.Application.PerfilRisco.Dtos;
using InvestFlowCaixa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestFlowCaixa.Application.PerfilRisco.Services
{
    public interface IPerfilRiscoService
    {
        Task<PerfilRiscoResponse> ObterPerfilAsync(int clienteId);
        (string Nome, string Descricao, int Score) AnalisarPerfil(Cliente cliente);
    }
}
