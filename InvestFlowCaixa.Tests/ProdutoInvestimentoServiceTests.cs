
using InvestFlowCaixa.Application.ProdutosInvestimento.Services;
using InvestFlowCaixa.Domain.Entities;
using InvestFlowCaixa.Domain.Interfaces;
using Moq;

namespace InvestFlowCaixa.Tests;

public class ProdutoInvestimentoServiceTests
{
    private readonly Mock<IProdutoInvestimentoRepository> _produtoRepoMock;
    private readonly Mock<IPerfilRiscoRepository> _perfilRiscoRepoMock;
    private readonly ProdutoInvestimentoService _service;

    public ProdutoInvestimentoServiceTests()
    {
        _produtoRepoMock = new Mock<IProdutoInvestimentoRepository>();
        _perfilRiscoRepoMock = new Mock<IPerfilRiscoRepository>();

        _service = new ProdutoInvestimentoService(
            _produtoRepoMock.Object,
            _perfilRiscoRepoMock.Object
        );
    }

    // =====================================================================
    // HELPERS
    // =====================================================================

    private ProdutoInvestimento CriarProduto(int id, string risco, decimal rentabilidade,
                                             decimal min = 1000, int maxPrazo = 36)
    {
        return new ProdutoInvestimento
        {
            Id = id,
            Nome = $"Produto {id} {risco}",
            Tipo = "CDB",
            Rentabilidade = rentabilidade,
            Risco = risco,
            MinValor = min,
            MaxPrazoMeses = maxPrazo
        };
    }

    // =====================================================================
    // TESTES - ObterProdutosDoTipoAsync
    // =====================================================================

    [Fact]
    public async Task ObterProdutosDoTipoAsync_DeveRetornarProdutosDoRepositorio()
    {
        var produtos = new List<ProdutoInvestimento>
        {
            CriarProduto(1, "Baixo", 0.10m),
            CriarProduto(2, "Moderado", 0.12m),
        };

        _produtoRepoMock.Setup(r => r.GetByTipoAsync("CDB"))
                        .ReturnsAsync(produtos);

        var result = await _service.ObterProdutosDoTipoAsync("CDB");

        Assert.Equal(2, result.Count());
    }

    // =====================================================================
    // TESTES - ObterRiscosPermitidos
    // =====================================================================

    [Theory]
    [InlineData("Conservador", new[] { "Baixo" })]
    [InlineData("Moderado", new[] { "Baixo", "Moderado" })]
    [InlineData("Agressivo", new[] { "Baixo", "Moderado", "Alto" })]
    public void ObterRiscosPermitidos_DeveRetornarListaCorreta(string perfil, string[] expected)
    {
        var result = _service.ObterRiscosPermitidos(perfil);
        Assert.Equal(expected, result);
    }

    // =====================================================================
    // TESTES - FiltrarElegiveis
    // =====================================================================

    [Fact]
    public void FiltrarElegiveis_DeveRetornarProdutosQueAtendemCriterios()
    {
        var produtos = new List<ProdutoInvestimento>
        {
            CriarProduto(1, "Baixo", 0.10m, min: 1000, maxPrazo: 12),
            CriarProduto(2, "Baixo", 0.10m, min: 20000, maxPrazo: 12),
            CriarProduto(3, "Baixo", 0.10m, min: 1000, maxPrazo: 6),
        };

        var result = _service.FiltrarElegiveis(produtos, valor: 5000, prazoMeses: 12);

        Assert.Single(result);  // só o produto 1
        Assert.Equal(1, result.First().Id);
    }

    // =====================================================================
    // TESTES - SelecionarMelhorProduto
    // =====================================================================

    [Fact]
    public void SelecionarMelhorProduto_DeveSelecionarProdutoNoMesmoRisco_Conservador()
    {
        var produtos = new List<ProdutoInvestimento>
        {
            CriarProduto(1, "Baixo", 0.10m),
            CriarProduto(2, "Baixo", 0.12m), // melhor
            CriarProduto(3, "Moderado", 0.20m),
        };

        var result = _service.SelecionarMelhorProduto(produtos, "Conservador");

        Assert.Equal(2, result.Id);
    }

    [Fact]
    public void SelecionarMelhorProduto_DeveBuscarNiveisInferiores()
    {
        var produtos = new List<ProdutoInvestimento>
        {
            CriarProduto(1, "Baixo", 0.15m), // deve ser escolhido
            CriarProduto(2, "Alto", 0.30m)
        };

        // Cliente Moderado: nível "Moderado"
        // Se não houver "Moderado": desce para "Baixo"

        var result = _service.SelecionarMelhorProduto(produtos, "Moderado");

        Assert.Equal(1, result.Id);
    }

    [Fact]
    public void SelecionarMelhorProduto_DeveBuscarNiveisSuperiores()
    {
        var produtos = new List<ProdutoInvestimento>
        {
            CriarProduto(1, "Moderado", 0.12m),
            CriarProduto(2, "Alto", 0.25m),   // melhor superior
        };

        var result = _service.SelecionarMelhorProduto(produtos, "Conservador");

        Assert.Equal(1, result.Id);   // Moderado é escolhido antes de Alto
    }

    [Fact]
    public void SelecionarMelhorProduto_DeveEscolherMaiorRentabilidade_QuandoNenhumNivelBate()
    {
        var produtos = new List<ProdutoInvestimento>
        {
            CriarProduto(1, "Alto", 0.10m),
            CriarProduto(2, "Moderado", 0.40m), // maior rentabilidade geral
            CriarProduto(3, "Baixo", 0.30m),    // primeiro risco compatível para perfil desconhecido
        };

        var result = _service.SelecionarMelhorProduto(produtos, "PerfilInexistente");

        Assert.Equal(3, result.Id);
    }

    // =====================================================================
    // TESTES - ObterProdutosRecomendadosPorPerfilAsync
    // =====================================================================

    [Fact]
    public async Task ObterProdutosRecomendadosPorPerfilAsync_DeveRetornarMelhorProdutoPorTipo()
    {
        var perfil = new PerfilRisco { Id = 2, Nome = "Moderado" };

        _perfilRiscoRepoMock.Setup(r => r.ObterPorIdAsync(2))
                            .ReturnsAsync(perfil);

        _produtoRepoMock.Setup(r => r.GetTiposDisponiveisAsync())
                        .ReturnsAsync(new List<string> { "CDB", "LCI" });

        var produtosCdb = new List<ProdutoInvestimento>
        {
            CriarProduto(1, "Baixo", 0.10m),
            CriarProduto(2, "Moderado", 0.12m) // deveria ser escolhido
        };

        var produtosLci = new List<ProdutoInvestimento>
        {
            // sem produto "Moderado", deve escolher "Baixo"
            CriarProduto(3, "Baixo", 0.11m),
        };

        _produtoRepoMock.Setup(r => r.GetByTipoAsync("CDB"))
                        .ReturnsAsync(produtosCdb);

        _produtoRepoMock.Setup(r => r.GetByTipoAsync("LCI"))
                        .ReturnsAsync(produtosLci);

        // Força a seleção correta por tipo para o perfil "Moderado"
        _produtoRepoMock.Setup(r => r.GetByTipoAsync(It.IsAny<string>()))
                        .ReturnsAsync((string tipo) =>
                        {
                            return tipo == "CDB" ? produtosCdb : produtosLci;
                        });

        var result = await _service.ObterProdutosRecomendadosPorPerfilAsync(2);

        Assert.Equal(2, result.Count());  // 1 por tipo
        Assert.Contains(result, p => p.Id == 2); // CDB Moderado 0.12
        Assert.Contains(result, p => p.Id == 3); // LCI 0.11
    }
}