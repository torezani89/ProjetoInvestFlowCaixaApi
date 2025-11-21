using AutoMapper;
using InvestFlowCaixa.Domain.Entities;
using InvestFlowCaixa.Application.Clientes.Dtos;

namespace InvestFlowCaixa.Application.Clientes.Mapping
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            // ClienteCriacaoDto → Cliente
            CreateMap<ClienteCriacaoDto, Cliente>();

            CreateMap<ClienteAtualizacaoDto, Cliente>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            //.ForMember(dest => dest.Id, opt => opt.Ignore());


            CreateMap<Cliente, ClienteRespostaDto>();
        }
    }
}
