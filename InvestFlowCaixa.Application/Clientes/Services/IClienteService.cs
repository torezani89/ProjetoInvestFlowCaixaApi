using InvestFlowCaixa.Application.Authentication.Dtos;
using InvestFlowCaixa.Application.Clientes.Dtos;
using InvestFlowCaixa.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestFlowCaixa.Application.Clientes.Services
{
    public interface IClienteService
    {
        Task<ClienteRespostaDto> ObterPorIdAsync(int id);
        Task<ClienteRespostaDto> CriarAsync(ClienteCriacaoDto dto);
        Task<ClienteRespostaDto> AtualizarAsync(int id, ClienteAtualizacaoDto dto);
        Task RemoverAsync(int id);
    }

}
