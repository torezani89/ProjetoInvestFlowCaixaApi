using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvestFlowCaixa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSimulacoesSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Simulacoes",
                columns: new[] { "Id", "ClienteId", "DataSimulacao", "PrazoMeses", "ProdutoInvestimentoId", "RentabilidadeEfetiva", "ValorFinal", "ValorInvestido" },
                values: new object[,]
                {
                    { 3001, 101, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 1, 0.1125m, 2225m, 2000m },
                    { 3002, 101, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 3, 0.11m, 1110m, 1000m },
                    { 3003, 101, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 12, 0.09m, 5450m, 5000m },
                    { 3004, 102, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 4, 0.14m, 3420m, 3000m },
                    { 3005, 102, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 18, 0.14m, 7980m, 7000m },
                    { 3006, 102, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 21, 0.18m, 2360m, 2000m },
                    { 3007, 103, new DateTime(2025, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 7, 0.19m, 4760m, 4000m },
                    { 3008, 103, new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 24, 0.19m, 9520m, 8000m },
                    { 3009, 103, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 27, 0.24m, 6200m, 5000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Simulacoes",
                keyColumn: "Id",
                keyValue: 3001);

            migrationBuilder.DeleteData(
                table: "Simulacoes",
                keyColumn: "Id",
                keyValue: 3002);

            migrationBuilder.DeleteData(
                table: "Simulacoes",
                keyColumn: "Id",
                keyValue: 3003);

            migrationBuilder.DeleteData(
                table: "Simulacoes",
                keyColumn: "Id",
                keyValue: 3004);

            migrationBuilder.DeleteData(
                table: "Simulacoes",
                keyColumn: "Id",
                keyValue: 3005);

            migrationBuilder.DeleteData(
                table: "Simulacoes",
                keyColumn: "Id",
                keyValue: 3006);

            migrationBuilder.DeleteData(
                table: "Simulacoes",
                keyColumn: "Id",
                keyValue: 3007);

            migrationBuilder.DeleteData(
                table: "Simulacoes",
                keyColumn: "Id",
                keyValue: 3008);

            migrationBuilder.DeleteData(
                table: "Simulacoes",
                keyColumn: "Id",
                keyValue: 3009);
        }
    }
}
