using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InvestFlowCaixa.Domain.Entities;

namespace InvestFlowCaixa.Infrastructure.Data.Configurations
{
    public class TelemetriaSeed : IEntityTypeConfiguration<TelemetriaServico>
    {
        public void Configure(EntityTypeBuilder<TelemetriaServico> builder)
        {
            builder.HasData(
                new TelemetriaServico
                {
                    Id = 4014,
                    NomeServico = "perfil-risco",
                    QuantidadeChamadas = 9,
                    TempoMedioRespostaMs = 41,
                    DataReferencia = new DateTime(2025, 10, 10)
                },
                new TelemetriaServico
                {
                    Id = 4015,
                    NomeServico = "simular-investimento",
                    QuantidadeChamadas = 3,
                    TempoMedioRespostaMs = 512,
                    DataReferencia = new DateTime(2025, 10, 10)
                },
                new TelemetriaServico
                {
                    Id = 4016,
                    NomeServico = "perfil-risco",
                    QuantidadeChamadas = 12,
                    TempoMedioRespostaMs = 38,
                    DataReferencia = new DateTime(2025, 10, 15)
                },
                new TelemetriaServico
                {
                    Id = 4017,
                    NomeServico = "simular-investimento",
                    QuantidadeChamadas = 5,
                    TempoMedioRespostaMs = 480,
                    DataReferencia = new DateTime(2025, 10, 15)
                },
                new TelemetriaServico
                {
                    Id = 4018,
                    NomeServico = "perfil-risco",
                    QuantidadeChamadas = 14,
                    TempoMedioRespostaMs = 43,
                    DataReferencia = new DateTime(2025, 10, 20)
                },
                new TelemetriaServico
                {
                    Id = 4019,
                    NomeServico = "simular-investimento",
                    QuantidadeChamadas = 6,
                    TempoMedioRespostaMs = 505,
                    DataReferencia = new DateTime(2025, 10, 20)
                },
                new TelemetriaServico
                {
                    Id = 4020,
                    NomeServico = "perfil-risco",
                    QuantidadeChamadas = 16,
                    TempoMedioRespostaMs = 37,
                    DataReferencia = new DateTime(2025, 11, 01)
                },
                new TelemetriaServico
                {
                    Id = 4021,
                    NomeServico = "simular-investimento",
                    QuantidadeChamadas = 4,
                    TempoMedioRespostaMs = 450,
                    DataReferencia = new DateTime(2025, 11, 01)
                },
                new TelemetriaServico
                {
                    Id = 4022,
                    NomeServico = "perfil-risco",
                    QuantidadeChamadas = 10,
                    TempoMedioRespostaMs = 40,
                    DataReferencia = new DateTime(2025, 11, 10)
                },
                new TelemetriaServico
                {
                    Id = 4023,
                    NomeServico = "simular-investimento",
                    QuantidadeChamadas = 7,
                    TempoMedioRespostaMs = 530,
                    DataReferencia = new DateTime(2025, 11, 10)
                }

            );
        }
    }
}
