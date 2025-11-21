using InvestFlowCaixa.Application.Authentication.Services;
using InvestFlowCaixa.Application.Clientes.Services;
using InvestFlowCaixa.Application.HistoricoInvestimentos.Services;
using InvestFlowCaixa.Application.Historicos.Services;
using InvestFlowCaixa.Application.PerfilRisco.Services;
using InvestFlowCaixa.Application.ProdutosInvestimento.Services;
using InvestFlowCaixa.Application.Simulacoes.Services;
using InvestFlowCaixa.Application.Telemetria.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InvestFlowCaixa.Application.DependencyInjection
{
    public static class ApplicationInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // AutoMapper (escaneia todos os profiles da Application)
            services.AddAutoMapper(typeof(ApplicationInjection).Assembly);

            // Serviços da aplicação
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ISimulacaoService, SimulacaoService>();
            services.AddScoped<ISenhaService, SenhaService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPerfilRiscoService, PerfilRiscoService>();
            services.AddScoped<IProdutoInvestimentoService, ProdutoInvestimentoService>();
            services.AddScoped<IHistoricoInvestimentoService, HistoricoInvestimentoService>();
            services.AddScoped<ITelemetriaService, TelemetriaService>();

            return services;
        }
    }
}
