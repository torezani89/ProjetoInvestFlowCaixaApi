using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvestFlowCaixa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedsTableProdutosInvestimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProdutosInvestimento",
                columns: new[] { "Id", "Liquidez", "MaxPrazoMeses", "MinValor", "Nome", "Rentabilidade", "Risco", "Tipo" },
                values: new object[,]
                {
                    { 4, "D+15", 36, 2000m, "CDB Caixa Performance", 0.132m, "Moderado", "CDB" },
                    { 5, "D+120", 48, 7000m, "LCI Caixa Desenvolvimento", 0.115m, "Moderado", "LCI" },
                    { 6, "D+1", 60, 100m, "Tesouro Prefixado 2029", 0.145m, "Moderado", "Tesouro" },
                    { 7, "D+30", 60, 1000m, "CDB Retorno Turbo XPTO", 0.165m, "Alto", "CDB" },
                    { 8, "D+180", 72, 8000m, "LCI FlexMax Corporativa", 0.152m, "Alto", "LCI" },
                    { 9, "D+1", 120, 100m, "Tesouro Prefixado 2035 Alta Volatilidade", 0.185m, "Alto", "Tesouro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
