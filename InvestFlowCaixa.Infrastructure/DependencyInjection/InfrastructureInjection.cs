using InvestFlowCaixa.Domain.Interfaces;
using InvestFlowCaixa.Infrastructure.Data;
using InvestFlowCaixa.Infrastructure.Repositories;
using InvestFlowCaixa.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvestFlowCaixa.Infrastructure.DependencyInjection
{
    public static class InfrastructureInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // 📌 1. Registro do DbContext
            services.AddDbContext<InvestimentosDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            // 📌 2. Registros de repositórios
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ISimulacaoRepository, SimulacaoRepository>();
            services.AddScoped<IProdutoInvestimentoRepository, ProdutoInvestimentoRepository>();
            services.AddScoped<IPerfilRiscoRepository, PerfilRiscoRepository>();
            services.AddScoped<IHistoricoInvestimentoRepository, HistoricoInvestimentoRepository>();
            services.AddScoped<ITelemetriaRepository, TelemetriaRepository>();

            return services;
        }
    }
}
