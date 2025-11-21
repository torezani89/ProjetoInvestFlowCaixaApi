using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvestFlowCaixa.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    RendaMensal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FrequenciaMovimentacoes = table.Column<int>(type: "int", nullable: false),
                    PreferenciaLiquidez = table.Column<int>(type: "int", nullable: false),
                    PreferenciaRentabilidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PerfisRisco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PontuacaoMin = table.Column<int>(type: "int", nullable: false),
                    PontuacaoMax = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerfisRisco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosInvestimento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rentabilidade = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Risco = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Liquidez = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MinValor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxPrazoMeses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosInvestimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelemetriaServicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeServico = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    QuantidadeChamadas = table.Column<int>(type: "int", nullable: false),
                    TempoMedioRespostaMs = table.Column<int>(type: "int", nullable: false),
                    DataReferencia = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelemetriaServicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoInvestimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Rentabilidade = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoInvestimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoInvestimentos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Simulacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    ProdutoInvestimentoId = table.Column<int>(type: "int", nullable: false),
                    ValorInvestido = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ValorFinal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PrazoMeses = table.Column<int>(type: "int", nullable: false),
                    RentabilidadeEfetiva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataSimulacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simulacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Simulacoes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Simulacoes_ProdutosInvestimento_ProdutoInvestimentoId",
                        column: x => x.ProdutoInvestimentoId,
                        principalTable: "ProdutosInvestimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoInvestimentos_ClienteId",
                table: "HistoricoInvestimentos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Simulacoes_ClienteId_DataSimulacao",
                table: "Simulacoes",
                columns: new[] { "ClienteId", "DataSimulacao" });

            migrationBuilder.CreateIndex(
                name: "IX_Simulacoes_ProdutoInvestimentoId",
                table: "Simulacoes",
                column: "ProdutoInvestimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_TelemetriaServicos_NomeServico",
                table: "TelemetriaServicos",
                column: "NomeServico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoInvestimentos");

            migrationBuilder.DropTable(
                name: "PerfisRisco");

            migrationBuilder.DropTable(
                name: "Simulacoes");

            migrationBuilder.DropTable(
                name: "TelemetriaServicos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "ProdutosInvestimento");
        }
    }
}
