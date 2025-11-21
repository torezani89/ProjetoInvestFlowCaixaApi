using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestFlowCaixa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddScoreClientesSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 101,
                column: "Score",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 102,
                column: "Score",
                value: 46);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 103,
                column: "Score",
                value: 76);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 101,
                column: "Score",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 102,
                column: "Score",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 103,
                column: "Score",
                value: 0);
        }
    }
}
