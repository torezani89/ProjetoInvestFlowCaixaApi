using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InvestFlowCaixa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTelemetriaSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4001);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4002);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4003);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4004);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4005);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4006);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4007);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4008);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4009);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4010);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4011);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4012);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4013);

            migrationBuilder.InsertData(
                table: "TelemetriaServicos",
                columns: new[] { "Id", "DataReferencia", "NomeServico", "QuantidadeChamadas", "TempoMedioRespostaMs" },
                values: new object[,]
                {
                    { 4014, new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "perfil-risco", 9, 41 },
                    { 4015, new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "simular-investimento", 3, 512 },
                    { 4016, new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "perfil-risco", 12, 38 },
                    { 4017, new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "simular-investimento", 5, 480 },
                    { 4018, new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "perfil-risco", 14, 43 },
                    { 4019, new DateTime(2025, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "simular-investimento", 6, 505 },
                    { 4020, new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "perfil-risco", 16, 37 },
                    { 4021, new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "simular-investimento", 4, 450 },
                    { 4022, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "perfil-risco", 10, 40 },
                    { 4023, new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "simular-investimento", 7, 530 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4014);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4015);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4016);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4017);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4018);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4019);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4020);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4021);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4022);

            migrationBuilder.DeleteData(
                table: "TelemetriaServicos",
                keyColumn: "Id",
                keyValue: 4023);

            migrationBuilder.InsertData(
                table: "TelemetriaServicos",
                columns: new[] { "Id", "DataReferencia", "NomeServico", "QuantidadeChamadas", "TempoMedioRespostaMs" },
                values: new object[,]
                {
                    { 4001, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "perfil-risco", 11, 37 },
                    { 4002, new DateTime(2025, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "simular-investimento", 2, 428 },
                    { 4003, new DateTime(2025, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "simular-investimento", 4, 879 },
                    { 4004, new DateTime(2025, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "perfil-risco", 15, 42 },
                    { 4005, new DateTime(2025, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "perfil-risco", 18, 39 },
                    { 4006, new DateTime(2025, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "simular-investimento", 7, 512 },
                    { 4007, new DateTime(2025, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "simular-investimento", 5, 463 },
                    { 4008, new DateTime(2025, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "obter-cliente", 21, 28 },
                    { 4009, new DateTime(2025, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "listar-produtos", 12, 19 },
                    { 4010, new DateTime(2025, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "historico-cliente", 9, 75 },
                    { 4011, new DateTime(2025, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "criar-simulacao", 3, 512 },
                    { 4012, new DateTime(2025, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "atualizar-cliente", 4, 132 },
                    { 4013, new DateTime(2025, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "listar-produtos", 17, 22 }
                });
        }
    }
}
