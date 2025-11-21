using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvestFlowCaixa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedProdutosInvestimentoTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProdutosInvestimento",
                columns: new[] { "Id", "Liquidez", "MaxPrazoMeses", "MinValor", "Nome", "Rentabilidade", "Risco", "Tipo" },
                values: new object[,]
                {
                    { 10, "D+1", 36, 2000m, "CDB Caixa Estabilidade", 0.118m, "Baixo", "CDB" },
                    { 11, "D+1", 48, 3000m, "CDB Caixa Conservador Plus", 0.121m, "Baixo", "CDB" },
                    { 12, "D+120", 48, 6000m, "LCI Caixa Habitação Popular", 0.097m, "Baixo", "LCI" },
                    { 13, "D+180", 60, 8000m, "LCI Caixa Infraestrutura Residencial", 0.101m, "Baixo", "LCI" },
                    { 14, "D+1", 60, 100m, "Tesouro Selic 2029", 0.108m, "Baixo", "Tesouro" },
                    { 15, "D+1", 72, 200m, "Tesouro Selic 2031", 0.112m, "Baixo", "Tesouro" },
                    { 16, "D+30", 48, 3000m, "CDB Caixa Dinâmico", 0.138m, "Moderado", "CDB" },
                    { 17, "D+60", 60, 4000m, "CDB Caixa Evolução", 0.143m, "Moderado", "CDB" },
                    { 18, "D+150", 60, 9000m, "LCI Caixa Corporativa", 0.123m, "Moderado", "LCI" },
                    { 19, "D+180", 72, 12000m, "LCI Caixa Premium", 0.129m, "Moderado", "LCI" },
                    { 20, "D+1", 72, 150m, "Tesouro Prefixado 2031", 0.152m, "Moderado", "Tesouro" },
                    { 21, "D+1", 96, 200m, "Tesouro IPCA+ 2035 Moderado", 0.158m, "Moderado", "Tesouro" },
                    { 22, "D+45", 72, 2000m, "CDB Potencial Max", 0.175m, "Alto", "CDB" },
                    { 23, "D+90", 96, 4000m, "CDB Renda Turbo", 0.188m, "Alto", "CDB" },
                    { 24, "D+240", 84, 10000m, "LCI Caixa MaxInvest", 0.163m, "Alto", "LCI" },
                    { 25, "D+360", 96, 15000m, "LCI Caixa HighYield", 0.172m, "Alto", "LCI" },
                    { 26, "D+1", 144, 200m, "Tesouro Prefixado 2040 HighVol", 0.198m, "Alto", "Tesouro" },
                    { 27, "D+1", 180, 500m, "Tesouro IPCA+ 2045 HighRisk", 0.215m, "Alto", "Tesouro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 27);
        }
    }
}
