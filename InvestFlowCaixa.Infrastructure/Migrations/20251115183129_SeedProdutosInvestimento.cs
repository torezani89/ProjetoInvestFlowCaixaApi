using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvestFlowCaixa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedProdutosInvestimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProdutosInvestimento",
                columns: new[] { "Id", "Liquidez", "MaxPrazoMeses", "MinValor", "Nome", "Rentabilidade", "Risco", "Tipo" },
                values: new object[,]
                {
                    { 1, "D+1", 24, 1000m, "CDB Banco Caixa", 0.1125m, "Baixo", "CDB" },
                    { 2, "D+90", 36, 5000m, "LCI Caixa Imobiliário", 0.092m, "Baixo", "LCI" },
                    { 3, "D+1", 48, 50m, "Tesouro Selic 2027", 0.1035m, "Baixo", "Tesouro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProdutosInvestimento",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
