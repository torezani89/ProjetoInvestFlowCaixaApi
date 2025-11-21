using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InvestFlowCaixa.Domain.Entities;

namespace InvestFlowCaixa.Infrastructure.Data.Configurations
{
    public class SimulacaoSeed : IEntityTypeConfiguration<Simulacao>
    {
        public void Configure(EntityTypeBuilder<Simulacao> builder)
        {
            builder.HasData(
                // ================================
                // CLIENTE 101 – Conservador
                // ================================
                new Simulacao
                {
                    Id = 3001,
                    ClienteId = 101,
                    ProdutoInvestimentoId = 1, // CDB baixo risco
                    ValorInvestido = 2000m,
                    ValorFinal = 2225m,
                    PrazoMeses = 24,
                    RentabilidadeEfetiva = 0.1125m,
                    DataSimulacao = new DateTime(2025, 01, 10)
                },
                new Simulacao
                {
                    Id = 3002,
                    ClienteId = 101,
                    ProdutoInvestimentoId = 3, // Tesouro Selic
                    ValorInvestido = 1000m,
                    ValorFinal = 1110m,
                    PrazoMeses = 12,
                    RentabilidadeEfetiva = 0.11m,
                    DataSimulacao = new DateTime(2025, 02, 14)
                },
                new Simulacao
                {
                    Id = 3003,
                    ClienteId = 101,
                    ProdutoInvestimentoId = 12, // LCI baixo risco
                    ValorInvestido = 5000m,
                    ValorFinal = 5450m,
                    PrazoMeses = 18,
                    RentabilidadeEfetiva = 0.09m,
                    DataSimulacao = new DateTime(2025, 03, 01)
                },

                // ================================
                // CLIENTE 102 – Moderado
                // ================================
                new Simulacao
                {
                    Id = 3004,
                    ClienteId = 102,
                    ProdutoInvestimentoId = 4, // CDB moderado
                    ValorInvestido = 3000m,
                    ValorFinal = 3420m,
                    PrazoMeses = 18,
                    RentabilidadeEfetiva = 0.14m,
                    DataSimulacao = new DateTime(2025, 01, 20)
                },
                new Simulacao
                {
                    Id = 3005,
                    ClienteId = 102,
                    ProdutoInvestimentoId = 18, // LCI moderada
                    ValorInvestido = 7000m,
                    ValorFinal = 7980m,
                    PrazoMeses = 24,
                    RentabilidadeEfetiva = 0.14m,
                    DataSimulacao = new DateTime(2025, 02, 10)
                },
                new Simulacao
                {
                    Id = 3006,
                    ClienteId = 102,
                    ProdutoInvestimentoId = 21, // Tesouro IPCA moderado
                    ValorInvestido = 2000m,
                    ValorFinal = 2360m,
                    PrazoMeses = 24,
                    RentabilidadeEfetiva = 0.18m,
                    DataSimulacao = new DateTime(2025, 03, 05)
                },

                // ================================
                // CLIENTE 103 – Agressivo
                // ================================
                new Simulacao
                {
                    Id = 3007,
                    ClienteId = 103,
                    ProdutoInvestimentoId = 7, // CDB alto risco
                    ValorInvestido = 4000m,
                    ValorFinal = 4760m,
                    PrazoMeses = 12,
                    RentabilidadeEfetiva = 0.19m,
                    DataSimulacao = new DateTime(2025, 01, 12)
                },
                new Simulacao
                {
                    Id = 3008,
                    ClienteId = 103,
                    ProdutoInvestimentoId = 24, // LCI alto risco
                    ValorInvestido = 8000m,
                    ValorFinal = 9520m,
                    PrazoMeses = 18,
                    RentabilidadeEfetiva = 0.19m,
                    DataSimulacao = new DateTime(2025, 02, 18)
                },
                new Simulacao
                {
                    Id = 3009,
                    ClienteId = 103,
                    ProdutoInvestimentoId = 27, // Tesouro alto risco
                    ValorInvestido = 5000m,
                    ValorFinal = 6200m,
                    PrazoMeses = 24,
                    RentabilidadeEfetiva = 0.24m,
                    DataSimulacao = new DateTime(2025, 03, 10)
                }
            );
        }
    }
}
