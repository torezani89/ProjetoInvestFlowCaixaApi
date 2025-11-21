using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InvestFlowCaixa.Domain.Entities;

namespace InvestFlowCaixa.Infrastructure.Data.Configurations
{
    public class ProdutoInvestimentoSeed : IEntityTypeConfiguration<ProdutoInvestimento>
    {
        public void Configure(EntityTypeBuilder<ProdutoInvestimento> builder)
        {
            builder.HasData(
                    new ProdutoInvestimento
                    {
                        Id = 1,
                        Nome = "CDB Banco Caixa",
                        Tipo = "CDB",
                        Rentabilidade = 0.1125m,
                        Risco = "Baixo",
                        Liquidez = "D+1",
                        MinValor = 1000m,
                        MaxPrazoMeses = 24
                    },
                    new ProdutoInvestimento
                    {
                        Id = 2,
                        Nome = "LCI Caixa Imobiliário",
                        Tipo = "LCI",
                        Rentabilidade = 0.092m,
                        Risco = "Baixo",
                        Liquidez = "D+90",
                        MinValor = 5000m,
                        MaxPrazoMeses = 36
                    },
                    new ProdutoInvestimento
                    {
                        Id = 3,
                        Nome = "Tesouro Selic 2027",
                        Tipo = "Tesouro",
                        Rentabilidade = 0.1035m,
                        Risco = "Baixo",
                        Liquidez = "D+1",
                        MinValor = 50m,
                        MaxPrazoMeses = 48
                    },
                    new ProdutoInvestimento
                    {
                        Id = 4,
                        Nome = "CDB Caixa Performance",
                        Tipo = "CDB",
                        Rentabilidade = 0.132m,
                        Risco = "Moderado",
                        Liquidez = "D+15",
                        MinValor = 2000m,
                        MaxPrazoMeses = 36
                    },
                    new ProdutoInvestimento
                    {
                        Id = 5,
                        Nome = "LCI Caixa Desenvolvimento",
                        Tipo = "LCI",
                        Rentabilidade = 0.115m,
                        Risco = "Moderado",
                        Liquidez = "D+120",
                        MinValor = 7000m,
                        MaxPrazoMeses = 48
                    },
                    new ProdutoInvestimento
                    {
                        Id = 6,
                        Nome = "Tesouro Prefixado 2029",
                        Tipo = "Tesouro",
                        Rentabilidade = 0.145m,
                        Risco = "Moderado",
                        Liquidez = "D+1",
                        MinValor = 100m,
                        MaxPrazoMeses = 60
                    },
                    new ProdutoInvestimento
                    {
                        Id = 7,
                        Nome = "CDB Retorno Turbo XPTO",
                        Tipo = "CDB",
                        Rentabilidade = 0.165m,
                        Risco = "Alto",
                        Liquidez = "D+30",
                        MinValor = 1000m,
                        MaxPrazoMeses = 60
                    },
                    new ProdutoInvestimento
                    {
                        Id = 8,
                        Nome = "LCI FlexMax Corporativa",
                        Tipo = "LCI",
                        Rentabilidade = 0.152m,
                        Risco = "Alto",
                        Liquidez = "D+180",
                        MinValor = 8000m,
                        MaxPrazoMeses = 72
                    },
                    new ProdutoInvestimento
                    {
                        Id = 9,
                        Nome = "Tesouro Prefixado 2035 Alta Volatilidade",
                        Tipo = "Tesouro",
                        Rentabilidade = 0.185m,
                        Risco = "Alto",
                        Liquidez = "D+1",
                        MinValor = 100m,
                        MaxPrazoMeses = 120
                    },
                    new ProdutoInvestimento
                    {
                        Id = 10,
                        Nome = "CDB Caixa Estabilidade",
                        Tipo = "CDB",
                        Rentabilidade = 0.118m,
                        Risco = "Baixo",
                        Liquidez = "D+1",
                        MinValor = 2000m,
                        MaxPrazoMeses = 36
                    },
                    new ProdutoInvestimento
                    {
                        Id = 11,
                        Nome = "CDB Caixa Conservador Plus",
                        Tipo = "CDB",
                        Rentabilidade = 0.121m,
                        Risco = "Baixo",
                        Liquidez = "D+1",
                        MinValor = 3000m,
                        MaxPrazoMeses = 48
                    },
                    new ProdutoInvestimento
                    {
                        Id = 12,
                        Nome = "LCI Caixa Habitação Popular",
                        Tipo = "LCI",
                        Rentabilidade = 0.097m,
                        Risco = "Baixo",
                        Liquidez = "D+120",
                        MinValor = 6000m,
                        MaxPrazoMeses = 48
                    },
                    new ProdutoInvestimento
                    {
                        Id = 13,
                        Nome = "LCI Caixa Infraestrutura Residencial",
                        Tipo = "LCI",
                        Rentabilidade = 0.101m,
                        Risco = "Baixo",
                        Liquidez = "D+180",
                        MinValor = 8000m,
                        MaxPrazoMeses = 60
                    },
                    new ProdutoInvestimento
                    {
                        Id = 14,
                        Nome = "Tesouro Selic 2029",
                        Tipo = "Tesouro",
                        Rentabilidade = 0.108m,
                        Risco = "Baixo",
                        Liquidez = "D+1",
                        MinValor = 100m,
                        MaxPrazoMeses = 60
                    },
                    new ProdutoInvestimento
                    {
                        Id = 15,
                        Nome = "Tesouro Selic 2031",
                        Tipo = "Tesouro",
                        Rentabilidade = 0.112m,
                        Risco = "Baixo",
                        Liquidez = "D+1",
                        MinValor = 200m,
                        MaxPrazoMeses = 72
                    },
                    new ProdutoInvestimento
                    {
                        Id = 16,
                        Nome = "CDB Caixa Dinâmico",
                        Tipo = "CDB",
                        Rentabilidade = 0.138m,
                        Risco = "Moderado",
                        Liquidez = "D+30",
                        MinValor = 3000m,
                        MaxPrazoMeses = 48
                    },
                    new ProdutoInvestimento
                    {
                        Id = 17,
                        Nome = "CDB Caixa Evolução",
                        Tipo = "CDB",
                        Rentabilidade = 0.143m,
                        Risco = "Moderado",
                        Liquidez = "D+60",
                        MinValor = 4000m,
                        MaxPrazoMeses = 60
                    },
                    new ProdutoInvestimento
                    {
                        Id = 18,
                        Nome = "LCI Caixa Corporativa",
                        Tipo = "LCI",
                        Rentabilidade = 0.123m,
                        Risco = "Moderado",
                        Liquidez = "D+150",
                        MinValor = 9000m,
                        MaxPrazoMeses = 60
                    },
                    new ProdutoInvestimento
                    {
                        Id = 19,
                        Nome = "LCI Caixa Premium",
                        Tipo = "LCI",
                        Rentabilidade = 0.129m,
                        Risco = "Moderado",
                        Liquidez = "D+180",
                        MinValor = 12000m,
                        MaxPrazoMeses = 72
                    },
                    new ProdutoInvestimento
                    {
                        Id = 20,
                        Nome = "Tesouro Prefixado 2031",
                        Tipo = "Tesouro",
                        Rentabilidade = 0.152m,
                        Risco = "Moderado",
                        Liquidez = "D+1",
                        MinValor = 150m,
                        MaxPrazoMeses = 72
                    },
                    new ProdutoInvestimento
                    {
                        Id = 21,
                        Nome = "Tesouro IPCA+ 2035 Moderado",
                        Tipo = "Tesouro",
                        Rentabilidade = 0.158m,
                        Risco = "Moderado",
                        Liquidez = "D+1",
                        MinValor = 200m,
                        MaxPrazoMeses = 96
                    },
                    new ProdutoInvestimento
                    {
                        Id = 22,
                        Nome = "CDB Potencial Max",
                        Tipo = "CDB",
                        Rentabilidade = 0.175m,
                        Risco = "Alto",
                        Liquidez = "D+45",
                        MinValor = 2000m,
                        MaxPrazoMeses = 72
                    },
                    new ProdutoInvestimento
                    {
                        Id = 23,
                        Nome = "CDB Renda Turbo",
                        Tipo = "CDB",
                        Rentabilidade = 0.188m,
                        Risco = "Alto",
                        Liquidez = "D+90",
                        MinValor = 4000m,
                        MaxPrazoMeses = 96
                    },
                    new ProdutoInvestimento
                    {
                        Id = 24,
                        Nome = "LCI Caixa MaxInvest",
                        Tipo = "LCI",
                        Rentabilidade = 0.163m,
                        Risco = "Alto",
                        Liquidez = "D+240",
                        MinValor = 10000m,
                        MaxPrazoMeses = 84
                    },
                    new ProdutoInvestimento
                    {
                        Id = 25,
                        Nome = "LCI Caixa HighYield",
                        Tipo = "LCI",
                        Rentabilidade = 0.172m,
                        Risco = "Alto",
                        Liquidez = "D+360",
                        MinValor = 15000m,
                        MaxPrazoMeses = 96
                    },
                    new ProdutoInvestimento
                    {
                        Id = 26,
                        Nome = "Tesouro Prefixado 2040 HighVol",
                        Tipo = "Tesouro",
                        Rentabilidade = 0.198m,
                        Risco = "Alto",
                        Liquidez = "D+1",
                        MinValor = 200m,
                        MaxPrazoMeses = 144
                    },
                    new ProdutoInvestimento
                    {
                        Id = 27,
                        Nome = "Tesouro IPCA+ 2045 HighRisk",
                        Tipo = "Tesouro",
                        Rentabilidade = 0.215m,
                        Risco = "Alto",
                        Liquidez = "D+1",
                        MinValor = 500m,
                        MaxPrazoMeses = 180
                    }
            );
        }
    }
}

