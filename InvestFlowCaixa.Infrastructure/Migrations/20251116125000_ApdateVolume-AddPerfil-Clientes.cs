using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestFlowCaixa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ApdateVolumeAddPerfilClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "VolumeInvestimentos",
                table: "Clientes",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PerfilId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PerfilId",
                table: "Clientes",
                column: "PerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_PerfisRisco_PerfilId",
                table: "Clientes",
                column: "PerfilId",
                principalTable: "PerfisRisco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_PerfisRisco_PerfilId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_PerfilId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "PerfilId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "VolumeInvestimentos",
                table: "Clientes",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);
        }
    }
}
