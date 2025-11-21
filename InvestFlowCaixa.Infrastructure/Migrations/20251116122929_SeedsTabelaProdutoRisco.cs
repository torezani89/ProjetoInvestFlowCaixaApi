using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvestFlowCaixa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedsTabelaProdutoRisco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PontuacaoMax",
                table: "PerfisRisco");

            migrationBuilder.DropColumn(
                name: "PontuacaoMin",
                table: "PerfisRisco");

            migrationBuilder.InsertData(
                table: "PerfisRisco",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Baixa movimentação e foco em liquidez.", "Conservador" },
                    { 2, "Equilíbrio entre liquidez e rentabilidade.", "Moderado" },
                    { 3, "Busca por alta rentabilidade assumindo maior risco.", "Agressivo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PerfisRisco",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PerfisRisco",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PerfisRisco",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "PontuacaoMax",
                table: "PerfisRisco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PontuacaoMin",
                table: "PerfisRisco",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
