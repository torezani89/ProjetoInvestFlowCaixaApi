using InvestFlowCaixa.Application.Simulacoes.Dtos;
using InvestFlowCaixa.Application.Simulacoes.Services;
using InvestFlowCaixa.Application.PerfilRisco.Services;
using InvestFlowCaixa.Application.ProdutosInvestimento.Services;
using InvestFlowCaixa.Domain.Entities;
using InvestFlowCaixa.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System.Globalization;
using Xunit;

public class SimulacaoServiceTests
{
    private readonly Mock<ISimulacaoRepository> _simRepoMock;
    private readonly Mock<IClienteRepository> _clienteRepoMock;
    private readonly Mock<IProdutoInvestimentoRepository> _produtoRepoMock;
    private readonly Mock<IProdutoInvestimentoService> _produtoServiceMock;
    private readonly Mock<IPerfilRiscoService> _perfilRiscoServiceMock;
    private readonly Mock<ILogger<SimulacaoService>> _loggerMock;

    private readonly SimulacaoService _service;

    public SimulacaoServiceTests()
    {
        _simRepoMock = new Mock<ISimulacaoRepository>();
        _clienteRepoMock = new Mock<IClienteRepository>();
        _produtoRepoMock = new Mock<IProdutoInvestimentoRepository>();
        _produtoServiceMock = new Mock<IProdutoInvestimentoService>();
        _perfilRiscoServiceMock = new Mock<IPerfilRiscoService>();
        _loggerMock = new Mock<ILogger<SimulacaoService>>();

        _service = new SimulacaoService(
            _simRepoMock.Object,
            _clienteRepoMock.Object,
            _perfilRiscoServiceMock.Object,
            _produtoRepoMock.Object,
            _produtoServiceMock.Object,
            _loggerMock.Object
        );
    }

    // =====================================================================
    // HELPERS
    // =====================================================================

    private SimulacaoRequestDto CriarRequestValido() =>
        new SimulacaoRequestDto
        {
            ClienteId = 1,
            Valor = 10000,
            PrazoMeses = 12,
            TipoProduto = "CDB"
        };

    private Cliente CriarClienteComPerfil(string perfil) =>
        new Cliente
        {
            Id = 1,
            Nome = "João",
            Perfil = new PerfilRisco { Nome = perfil }
        };

    private ProdutoInvestimento CriarProduto(
        int id,
        string risco,
        decimal rentabilidade,
        decimal min = 1000,
        int maxPrazo = 36) =>
        new ProdutoInvestimento
        {
            Id = id,
            Nome = $"CDB Teste {risco}",
            Tipo = "CDB",
            Rentabilidade = rentabilidade,
            Risco = risco,
            MinValor = min,
            MaxPrazoMeses = maxPrazo
        };

    // =====================================================================
    // TESTES DO SimularAsync
    // =====================================================================

    #region Validações iniciais

    [Fact]
    public async Task SimularAsync_DeveFalhar_QuandoRequestNulo()
    {
        await Assert.ThrowsAsync<ArgumentException>(() => _service.SimularAsync(null!));
    }

    [Fact]
    public async Task SimularAsync_DeveFalhar_QuandoClienteIdInvalido()
    {
        var req = CriarRequestValido();
        req.ClienteId = 0;

        await Assert.ThrowsAsync<ArgumentException>(() => _service.SimularAsync(req));
    }

    [Fact]
    public async Task SimularAsync_DeveFalhar_QuandoValorInvalido()
    {
        var req = CriarRequestValido();
        req.Valor = 0;

        await Assert.ThrowsAsync<ArgumentException>(() => _service.SimularAsync(req));
    }

    [Fact]
    public async Task SimularAsync_DeveFalhar_QuandoPrazoInvalido()
    {
        var req = CriarRequestValido();
        req.PrazoMeses = 0;

        await Assert.ThrowsAsync<ArgumentException>(() => _service.SimularAsync(req));
    }

    [Fact]
    public async Task SimularAsync_DeveFalhar_QuandoTipoProdutoVazio()
    {
        var req = CriarRequestValido();
        req.TipoProduto = "";

        await Assert.ThrowsAsync<ArgumentException>(() => _service.SimularAsync(req));
    }

    #endregion

    #region Cliente inválido

    [Fact]
    public async Task SimularAsync_DeveFalhar_QuandoClienteNaoExiste()
    {
        var req = CriarRequestValido();

        _clienteRepoMock.Setup(r => r.ObterClienteComPerfil(req.ClienteId))
                        .ReturnsAsync((Cliente?)null);

        await Assert.ThrowsAsync<KeyNotFoundException>(() => _service.SimularAsync(req));
    }

    [Fact]
    public async Task SimularAsync_DeveFalhar_QuandoClienteNaoTemPerfil()
    {
        var req = CriarRequestValido();

        _clienteRepoMock.Setup(r => r.ObterClienteComPerfil(req.ClienteId))
                        .ReturnsAsync(new Cliente { Id = 1, Nome = "Teste", Perfil = null });

        await Assert.ThrowsAsync<InvalidOperationException>(() => _service.SimularAsync(req));
    }

    #endregion

    #region Sem produtos do tipo solicitado

    [Fact]
    public async Task SimularAsync_DeveFalhar_QuandoNaoExisteProdutoDoTipo()
    {
        var req = CriarRequestValido();

        _clienteRepoMock.Setup(r => r.ObterClienteComPerfil(req.ClienteId))
                        .ReturnsAsync(CriarClienteComPerfil("Moderado"));

        _produtoServiceMock.Setup(s => s.ObterProdutosDoTipoAsync(req.TipoProduto))
                           .ReturnsAsync(new List<ProdutoInvestimento>());

        await Assert.ThrowsAsync<InvalidOperationException>(() => _service.SimularAsync(req));
    }

    #endregion

    #region Nenhum produto elegível

    [Fact]
    public async Task SimularAsync_DeveFalhar_QuandoNenhumProdutoElegivel()
    {
        var req = CriarRequestValido();
        var cliente = CriarClienteComPerfil("Moderado");

        _clienteRepoMock.Setup(r => r.ObterClienteComPerfil(req.ClienteId))
                        .ReturnsAsync(cliente);

        var produtos = new List<ProdutoInvestimento>
        {
            CriarProduto(1, "Baixo", 0.10m, min: 20000) // req.Valor = 10000 → não elegível
        };

        _produtoServiceMock.Setup(s => s.ObterProdutosDoTipoAsync(req.TipoProduto))
                           .ReturnsAsync(produtos);

        _produtoServiceMock.Setup(s => s.FiltrarElegiveis(produtos, req.Valor, req.PrazoMeses))
                           .Returns(new List<ProdutoInvestimento>());

        await Assert.ThrowsAsync<InvalidOperationException>(() => _service.SimularAsync(req));
    }

    #endregion

    #region Seleção do melhor produto

    [Fact]
    public async Task SimularAsync_DeveSelecionarMelhorProduto_QuandoNenhumCompatívelComRisco()
    {
        var req = CriarRequestValido();
        var cliente = CriarClienteComPerfil("Conservador"); // aceita só Baixo

        _clienteRepoMock.Setup(r => r.ObterClienteComPerfil(req.ClienteId))
                        .ReturnsAsync(cliente);

        var produtos = new List<ProdutoInvestimento>
        {
            CriarProduto(1, "Alto", 0.12m),
            CriarProduto(2, "Moderado", 0.11m)
        };

        _produtoServiceMock.Setup(s => s.ObterProdutosDoTipoAsync(req.TipoProduto))
                           .ReturnsAsync(produtos);

        _produtoServiceMock.Setup(s => s.FiltrarElegiveis(produtos, req.Valor, req.PrazoMeses))
                           .Returns(produtos);

        // Fallback: maior rentabilidade
        _produtoServiceMock
            .Setup(s => s.SelecionarMelhorProduto(produtos, "Conservador"))
            .Returns(produtos[0]); // 0.12m

        _simRepoMock.Setup(r => r.AddAsync(It.IsAny<Simulacao>()))
                    .Returns(Task.CompletedTask);

        var result = await _service.SimularAsync(req);

        Assert.Equal(0.12m, result.ResultadoSimulacao.RentabilidadeEfetiva);
        Assert.Equal(1, result.ProdutoValidado.Id);
    }

    [Fact]
    public async Task SimularAsync_DeveSelecionarMelhorProduto_EntreCompatíveis()
    {
        var req = CriarRequestValido();
        var cliente = CriarClienteComPerfil("Conservador");

        _clienteRepoMock.Setup(r => r.ObterClienteComPerfil(req.ClienteId))
                        .ReturnsAsync(cliente);

        var produtos = new List<ProdutoInvestimento>
        {
            CriarProduto(1, "Baixo", 0.15m),
            CriarProduto(2, "Baixo", 0.20m) // maior rentabilidade compatível
        };

        _produtoServiceMock.Setup(s => s.ObterProdutosDoTipoAsync("CDB"))
                           .ReturnsAsync(produtos);

        _produtoServiceMock.Setup(s => s.FiltrarElegiveis(produtos, req.Valor, req.PrazoMeses))
                           .Returns(produtos);

        _produtoServiceMock.Setup(s => s.SelecionarMelhorProduto(produtos, "Conservador"))
                           .Returns(produtos[1]);

        _simRepoMock.Setup(r => r.AddAsync(It.IsAny<Simulacao>()))
                    .Returns(Task.CompletedTask);

        var result = await _service.SimularAsync(req);

        Assert.Equal(0.20m, result.ResultadoSimulacao.RentabilidadeEfetiva);
        Assert.Equal(2, result.ProdutoValidado.Id);
    }

    #endregion

    #region Cálculo do valor final

    [Fact]
    public async Task SimularAsync_DeveCalcularValorFinalCorretamente()
    {
        var req = CriarRequestValido();
        var cliente = CriarClienteComPerfil("Conservador");

        _clienteRepoMock.Setup(r => r.ObterClienteComPerfil(req.ClienteId))
                        .ReturnsAsync(cliente);

        var produto = CriarProduto(1, "Baixo", 0.12m);

        _produtoServiceMock.Setup(s => s.ObterProdutosDoTipoAsync("CDB"))
                           .ReturnsAsync(new List<ProdutoInvestimento> { produto });

        _produtoServiceMock.Setup(s => s.FiltrarElegiveis(It.IsAny<IEnumerable<ProdutoInvestimento>>(), req.Valor, req.PrazoMeses))
                           .Returns(new List<ProdutoInvestimento> { produto });

        _produtoServiceMock.Setup(s => s.SelecionarMelhorProduto(It.IsAny<List<ProdutoInvestimento>>(), "Conservador"))
                           .Returns(produto);

        _simRepoMock.Setup(r => r.AddAsync(It.IsAny<Simulacao>()))
                    .Returns(Task.CompletedTask);

        var result = await _service.SimularAsync(req);

        Assert.Equal(req.PrazoMeses, result.ResultadoSimulacao.PrazoMeses);
        Assert.Equal(req.Valor.ToString("F2", CultureInfo.InvariantCulture),
                     result.ResultadoSimulacao.ValorInvestido);

        Assert.True(decimal.Parse(result.ResultadoSimulacao.ValorFinal, CultureInfo.InvariantCulture) > req.Valor);
    }

    #endregion
}
