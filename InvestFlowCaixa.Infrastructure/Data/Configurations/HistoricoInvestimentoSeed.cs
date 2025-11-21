using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InvestFlowCaixa.Domain.Entities;

namespace InvestFlowCaixa.Infrastructure.Data.Configurations
{
    public class HistoricoInvestimentoSeed : IEntityTypeConfiguration<HistoricoInvestimento>
    {
        public void Configure(EntityTypeBuilder<HistoricoInvestimento> builder)
        {
            builder.HasData(
                // CLIENTE 1 – PERFIL CONSERVADOR (BAIXO)
                new HistoricoInvestimento { Id = 1001, ClienteId = 101, Tipo = "CDB", Valor = 1000m, Rentabilidade = 0.1125m, Data = new DateTime(2025, 1, 5) },
                new HistoricoInvestimento { Id = 1002, ClienteId = 101, Tipo = "CDB", Valor = 2000m, Rentabilidade = 0.1180m, Data = new DateTime(2025, 1, 20) },
                new HistoricoInvestimento { Id = 1003, ClienteId = 101, Tipo = "CDB", Valor = 3000m, Rentabilidade = 0.1210m, Data = new DateTime(2025, 2, 1) },

                new HistoricoInvestimento { Id = 1004, ClienteId = 101, Tipo = "LCI", Valor = 5000m, Rentabilidade = 0.0920m, Data = new DateTime(2025, 2, 12) },
                new HistoricoInvestimento { Id = 1005, ClienteId = 101, Tipo = "LCI", Valor = 6000m, Rentabilidade = 0.0970m, Data = new DateTime(2025, 2, 28) },
                new HistoricoInvestimento { Id = 1006, ClienteId = 101, Tipo = "LCI", Valor = 8000m, Rentabilidade = 0.1010m, Data = new DateTime(2025, 3, 12) },

                new HistoricoInvestimento { Id = 1007, ClienteId = 101, Tipo = "Tesouro", Valor = 50m, Rentabilidade = 0.1035m, Data = new DateTime(2025, 1, 8) },
                new HistoricoInvestimento { Id = 1008, ClienteId = 101, Tipo = "Tesouro", Valor = 100m, Rentabilidade = 0.1080m, Data = new DateTime(2025, 2, 10) },
                new HistoricoInvestimento { Id = 1009, ClienteId = 101, Tipo = "Tesouro", Valor = 200m, Rentabilidade = 0.1120m, Data = new DateTime(2025, 3, 15) },

                // CLIENTE 2 – PERFIL MODERADO (MODERADO)
                new HistoricoInvestimento { Id = 1010, ClienteId = 102, Tipo = "CDB", Valor = 2000m, Rentabilidade = 0.1320m, Data = new DateTime(2025, 1, 3) },
                new HistoricoInvestimento { Id = 1011, ClienteId = 102, Tipo = "CDB", Valor = 3000m, Rentabilidade = 0.1380m, Data = new DateTime(2025, 2, 1) },
                new HistoricoInvestimento { Id = 1012, ClienteId = 102, Tipo = "CDB", Valor = 4000m, Rentabilidade = 0.1430m, Data = new DateTime(2025, 2, 22) },

                new HistoricoInvestimento { Id = 1013, ClienteId = 102, Tipo = "LCI", Valor = 7000m, Rentabilidade = 0.1150m, Data = new DateTime(2025, 1, 25) },
                new HistoricoInvestimento { Id = 1014, ClienteId = 102, Tipo = "LCI", Valor = 9000m, Rentabilidade = 0.1230m, Data = new DateTime(2025, 2, 14) },
                new HistoricoInvestimento { Id = 1015, ClienteId = 102, Tipo = "LCI", Valor = 12000m, Rentabilidade = 0.1290m, Data = new DateTime(2025, 3, 3) },

                new HistoricoInvestimento { Id = 1016, ClienteId = 102, Tipo = "Tesouro", Valor = 100m, Rentabilidade = 0.1450m, Data = new DateTime(2025, 1, 15) },
                new HistoricoInvestimento { Id = 1017, ClienteId = 102, Tipo = "Tesouro", Valor = 150m, Rentabilidade = 0.1520m, Data = new DateTime(2025, 2, 5) },
                new HistoricoInvestimento { Id = 1018, ClienteId = 102, Tipo = "Tesouro", Valor = 200m, Rentabilidade = 0.1580m, Data = new DateTime(2025, 3, 8) },

                // CLIENTE 3 – PERFIL AGRESSIVO (ALTO)
                new HistoricoInvestimento { Id = 1019, ClienteId = 103, Tipo = "CDB", Valor = 1000m, Rentabilidade = 0.1650m, Data = new DateTime(2025, 1, 10) },
                new HistoricoInvestimento { Id = 1020, ClienteId = 103, Tipo = "CDB", Valor = 2000m, Rentabilidade = 0.1750m, Data = new DateTime(2025, 1, 15) },
                new HistoricoInvestimento { Id = 1021, ClienteId = 103, Tipo = "CDB", Valor = 4000m, Rentabilidade = 0.1880m, Data = new DateTime(2025, 2, 5) },

                new HistoricoInvestimento { Id = 1022, ClienteId = 103, Tipo = "LCI", Valor = 8000m, Rentabilidade = 0.1520m, Data = new DateTime(2025, 2, 12) },
                new HistoricoInvestimento { Id = 1023, ClienteId = 103, Tipo = "LCI", Valor = 10000m, Rentabilidade = 0.1630m, Data = new DateTime(2025, 3, 1) },
                new HistoricoInvestimento { Id = 1024, ClienteId = 103, Tipo = "LCI", Valor = 15000m, Rentabilidade = 0.1720m, Data = new DateTime(2025, 3, 20) },

                new HistoricoInvestimento { Id = 1025, ClienteId = 103, Tipo = "Tesouro", Valor = 100m, Rentabilidade = 0.1850m, Data = new DateTime(2025, 1, 25) },
                new HistoricoInvestimento { Id = 1026, ClienteId = 103, Tipo = "Tesouro", Valor = 200m, Rentabilidade = 0.1980m, Data = new DateTime(2025, 2, 18) },
                new HistoricoInvestimento { Id = 1027, ClienteId = 103, Tipo = "Tesouro", Valor = 500m, Rentabilidade = 0.2150m, Data = new DateTime(2025, 3, 10) }
            );

        }
    }
}
