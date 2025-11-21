using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvestFlowCaixa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedsClientesEHistorico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "CPF", "FrequenciaMovimentacoes", "Nome", "PerfilId", "PreferenciaLiquidez", "PreferenciaRentabilidade", "RendaMensal", "Score", "SenhaHash", "SenhaSalt", "Token", "VolumeInvestimentos" },
                values: new object[,]
                {
                    { 101, "11111111111", 3, "Cliente Perfil Conservador", 1, 9, 2, 5000m, 0, new byte[] { 162, 210, 189, 177, 55, 43, 39, 132, 241, 224, 212, 51, 19, 125, 206, 43, 5, 39, 151, 242, 39, 111, 104, 152, 242, 221, 104, 179, 149, 221, 163, 213, 23, 89, 75, 142, 30, 120, 230, 127, 121, 62, 42, 33, 224, 242, 11, 140, 147, 18, 248, 106, 144, 211, 149, 244, 163, 223, 111, 220, 34, 10 }, new byte[] { 235, 173, 54, 10, 81, 190, 154, 77, 240, 33, 162, 46, 97, 220, 145, 143, 237, 233, 168, 180, 181, 87, 230, 94, 183, 55, 117, 62, 63, 147, 74, 12, 180, 24, 91, 201, 125, 190, 60, 34, 218, 39, 242, 113, 13, 18, 128, 120, 54, 15, 107, 92, 112, 214, 190, 201, 60, 29, 149, 162, 180, 177, 48 }, "", 20000m },
                    { 102, "22222222222", 10, "Cliente Perfil Moderado", 2, 5, 5, 8000m, 0, new byte[] { 162, 210, 189, 177, 55, 43, 39, 132, 241, 224, 212, 51, 19, 125, 206, 43, 5, 39, 151, 242, 39, 111, 104, 152, 242, 221, 104, 179, 149, 221, 163, 213, 23, 89, 75, 142, 30, 120, 230, 127, 121, 62, 42, 33, 224, 242, 11, 140, 147, 18, 248, 106, 144, 211, 149, 244, 163, 223, 111, 220, 34, 10 }, new byte[] { 235, 173, 54, 10, 81, 190, 154, 77, 240, 33, 162, 46, 97, 220, 145, 143, 237, 233, 168, 180, 181, 87, 230, 94, 183, 55, 117, 62, 63, 147, 74, 12, 180, 24, 91, 201, 125, 190, 60, 34, 218, 39, 242, 113, 13, 18, 128, 120, 54, 15, 107, 92, 112, 214, 190, 201, 60, 29, 149, 162, 180, 177, 48 }, "", 50000m },
                    { 103, "33333333333", 30, "Cliente Perfil Agressivo", 3, 1, 9, 15000m, 0, new byte[] { 162, 210, 189, 177, 55, 43, 39, 132, 241, 224, 212, 51, 19, 125, 206, 43, 5, 39, 151, 242, 39, 111, 104, 152, 242, 221, 104, 179, 149, 221, 163, 213, 23, 89, 75, 142, 30, 120, 230, 127, 121, 62, 42, 33, 224, 242, 11, 140, 147, 18, 248, 106, 144, 211, 149, 244, 163, 223, 111, 220, 34, 10 }, new byte[] { 235, 173, 54, 10, 81, 190, 154, 77, 240, 33, 162, 46, 97, 220, 145, 143, 237, 233, 168, 180, 181, 87, 230, 94, 183, 55, 117, 62, 63, 147, 74, 12, 180, 24, 91, 201, 125, 190, 60, 34, 218, 39, 242, 113, 13, 18, 128, 120, 54, 15, 107, 92, 112, 214, 190, 201, 60, 29, 149, 162, 180, 177, 48 }, "", 150000m }
                });

            migrationBuilder.InsertData(
                table: "HistoricoInvestimentos",
                columns: new[] { "Id", "ClienteId", "Data", "Rentabilidade", "Tipo", "Valor" },
                values: new object[,]
                {
                    { 1001, 101, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1125m, "CDB", 1000m },
                    { 1002, 101, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1180m, "CDB", 2000m },
                    { 1003, 101, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1210m, "CDB", 3000m },
                    { 1004, 101, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0920m, "LCI", 5000m },
                    { 1005, 101, new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.0970m, "LCI", 6000m },
                    { 1006, 101, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1010m, "LCI", 8000m },
                    { 1007, 101, new DateTime(2025, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1035m, "Tesouro", 50m },
                    { 1008, 101, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1080m, "Tesouro", 100m },
                    { 1009, 101, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1120m, "Tesouro", 200m },
                    { 1010, 102, new DateTime(2025, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1320m, "CDB", 2000m },
                    { 1011, 102, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1380m, "CDB", 3000m },
                    { 1012, 102, new DateTime(2025, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1430m, "CDB", 4000m },
                    { 1013, 102, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1150m, "LCI", 7000m },
                    { 1014, 102, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1230m, "LCI", 9000m },
                    { 1015, 102, new DateTime(2025, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1290m, "LCI", 12000m },
                    { 1016, 102, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1450m, "Tesouro", 100m },
                    { 1017, 102, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1520m, "Tesouro", 150m },
                    { 1018, 102, new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1580m, "Tesouro", 200m },
                    { 1019, 103, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1650m, "CDB", 1000m },
                    { 1020, 103, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1750m, "CDB", 2000m },
                    { 1021, 103, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1880m, "CDB", 4000m },
                    { 1022, 103, new DateTime(2025, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1520m, "LCI", 8000m },
                    { 1023, 103, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1630m, "LCI", 10000m },
                    { 1024, 103, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1720m, "LCI", 15000m },
                    { 1025, 103, new DateTime(2025, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1850m, "Tesouro", 100m },
                    { 1026, 103, new DateTime(2025, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.1980m, "Tesouro", 200m },
                    { 1027, 103, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.2150m, "Tesouro", 500m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1013);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1014);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1015);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1017);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1018);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1019);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1020);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1021);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1022);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1023);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1024);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1025);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1026);

            migrationBuilder.DeleteData(
                table: "HistoricoInvestimentos",
                keyColumn: "Id",
                keyValue: 1027);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 103);
        }
    }
}
