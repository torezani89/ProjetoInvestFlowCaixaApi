using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvestFlowCaixa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedsHistoricoInvestimentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "HistoricoInvestimentos",
                columns: new[] { "Id", "ClienteId", "Data", "Rentabilidade", "Tipo", "Valor" },
                values: new object[,]
                {
                    { 1, 12, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1650m, "CDB", 1000m },
                    { 2, 12, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1750m, "CDB", 2000m },
                    { 3, 12, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1880m, "CDB", 4000m },
                    { 4, 12, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1520m, "LCI", 8000m },
                    { 5, 12, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1630m, "LCI", 10000m },
                    { 6, 12, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1720m, "LCI", 15000m },
                    { 7, 12, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1850m, "Tesouro", 100m },
                    { 8, 12, new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1980m, "Tesouro", 200m },
                    { 9, 12, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.2150m, "Tesouro", 500m },
                    { 10, 14, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1125m, "CDB", 1000m },
                    { 11, 14, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1180m, "CDB", 2000m },
                    { 12, 14, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1210m, "CDB", 3000m },
                    { 13, 14, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0920m, "LCI", 5000m },
                    { 14, 14, new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0970m, "LCI", 6000m },
                    { 15, 14, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1010m, "LCI", 8000m },
                    { 16, 14, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1035m, "Tesouro", 50m },
                    { 17, 14, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1080m, "Tesouro", 100m },
                    { 18, 14, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1120m, "Tesouro", 200m },
                    { 19, 15, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1320m, "CDB", 2000m },
                    { 20, 15, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1380m, "CDB", 3000m },
                    { 21, 15, new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1430m, "CDB", 4000m },
                    { 22, 15, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1150m, "LCI", 7000m },
                    { 23, 15, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1230m, "LCI", 9000m },
                    { 24, 15, new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1290m, "LCI", 12000m },
                    { 25, 15, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1450m, "Tesouro", 100m },
                    { 26, 15, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1520m, "Tesouro", 150m },
                    { 27, 15, new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1580m, "Tesouro", 200m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Clientes",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
