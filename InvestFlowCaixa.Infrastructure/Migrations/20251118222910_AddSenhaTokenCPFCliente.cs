using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestFlowCaixa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSenhaTokenCPFCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Clientes",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "SenhaHash",
                table: "Clientes",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "SenhaSalt",
                table: "Clientes",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            // 2. Preencher CPFs temporários
            migrationBuilder.Sql(@"
                DECLARE @i INT = 1;
                UPDATE Clientes
                SET CPF = RIGHT('00000000000' + CAST(@i AS VARCHAR(11)), 11),
                    @i = @i + 1;
            ");

            // 3. Definir senha padrão '123' para todos
            migrationBuilder.Sql(@"
                UPDATE Clientes
                SET SenhaHash = CAST(N'mIO73vW+NVXYPLq31GpLvXQfUQo/Jjuy3iT36p3xBBYbCJHkexdRh5odKB/Gr8I+5G25XzhdQq27/FhkJ9uAqg==' AS VARBINARY(MAX)),
                    SenhaSalt = CAST(N'5hZtZJDc8mrvF9TickLpdWW7LL9LaOAeMZ0UZZJKbiZXbzCQMJ7kN2M8VujCqm5yOObQYCtKBQ2pU3rk8arSgw==' AS VARBINARY(MAX));
            ");

            // 3. Tornar NOT NULL
            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Clientes",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false);

            // 4. Criar Unique Index
            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CPF",
                table: "Clientes",
                column: "CPF",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_CPF",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "SenhaHash",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "SenhaSalt",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "Clientes");
        }
    }
}
