using AutoMapper;
using InvestFlowCaixa.Application.Authentication.Dtos;
using InvestFlowCaixa.Application.Authentication.Services;
using InvestFlowCaixa.Application.Clientes.Dtos;
using InvestFlowCaixa.Application.Clientes.Services;
using InvestFlowCaixa.Domain.Entities;
using InvestFlowCaixa.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace InvestFlowCaixa.Tests;
public class AuthServiceTests
{
    private readonly Mock<IClienteRepository> _repoMock;
    private readonly Mock<ISenhaService> _senhaServiceMock;
    private readonly Mock<ITokenService> _tokenServiceMock;
    private readonly Mock<ILogger<ClienteService>> _loggerMock;

    private readonly AuthService _service;

    public AuthServiceTests()
    {
        _repoMock = new Mock<IClienteRepository>();
        _senhaServiceMock = new Mock<ISenhaService>();
        _tokenServiceMock = new Mock<ITokenService>();
        _loggerMock = new Mock<ILogger<ClienteService>>();

        // mapper e PerfilRiscoAnalyzer não são usados no AuthService: passar null
        _service = new AuthService(
            _repoMock.Object,
            _loggerMock.Object,
            null!,
            _senhaServiceMock.Object,
            _tokenServiceMock.Object
        );
    }

    private AuthRequestDto CriarAuthRequestValido()
    {
        return new AuthRequestDto
        {
            CPF = "12345678901",
            Senha = "abc123"
        };
    }

    private Cliente CriarClienteFake()
    {
        return new Cliente
        {
            Id = 10,
            Nome = "João",
            CPF = "12345678901",
            SenhaHash = new byte[1],
            SenhaSalt = new byte[1],
            Token = ""
        };
    }

    // =============================================================
    // TESTES DO AuthAsync
    // =============================================================

    #region AuthAsync - Validations

    [Fact]
    public async Task AuthAsync_DeveFalhar_QuandoClienteNaoExiste()
    {
        var dto = CriarAuthRequestValido();

        _repoMock.Setup(r => r.ObterPorCpfAsync(dto.CPF))
                 .ReturnsAsync((Cliente?)null);

        await Assert.ThrowsAsync<KeyNotFoundException>(() => _service.AuthAsync(dto));
    }

    [Fact]
    public async Task AuthAsync_DeveFalhar_QuandoSenhaInvalida()
    {
        var dto = CriarAuthRequestValido();
        var cliente = CriarClienteFake();

        _repoMock.Setup(r => r.ObterPorCpfAsync(dto.CPF))
                 .ReturnsAsync(cliente);

        _senhaServiceMock.Setup(s => s.VerificarSenhaHash(dto.Senha, cliente.SenhaHash, cliente.SenhaSalt))
                         .Returns(false);

        await Assert.ThrowsAsync<UnauthorizedAccessException>(() => _service.AuthAsync(dto));
    }

    #endregion


    #region AuthAsync - Token e Update

    [Fact]
    public async Task AuthAsync_DeveGerarToken_QuandoCredenciaisValidas()
    {
        var dto = CriarAuthRequestValido();
        var cliente = CriarClienteFake();

        _repoMock.Setup(r => r.ObterPorCpfAsync(dto.CPF))
                 .ReturnsAsync(cliente);

        _senhaServiceMock.Setup(s => s.VerificarSenhaHash(dto.Senha, cliente.SenhaHash, cliente.SenhaSalt))
                         .Returns(true);

        _tokenServiceMock.Setup(t => t.CriarToken(cliente))
                         .Returns(new TokenResponseDto { Token = "TOKEN123" });

        _repoMock.Setup(r => r.UpdateAsync(cliente))
                 .Returns(Task.CompletedTask);

        var result = await _service.AuthAsync(dto);

        Assert.Equal(10, result.ClienteId);
        Assert.Equal("João", result.ClienteNome);
        Assert.Equal("TOKEN123", result.Token.Token);
    }

    [Fact]
    public async Task AuthAsync_DeveSalvarTokenNoCliente()
    {
        var dto = CriarAuthRequestValido();
        var cliente = CriarClienteFake();

        _repoMock.Setup(r => r.ObterPorCpfAsync(dto.CPF))
                 .ReturnsAsync(cliente);

        _senhaServiceMock.Setup(s => s.VerificarSenhaHash(dto.Senha, cliente.SenhaHash, cliente.SenhaSalt))
                         .Returns(true);

        _tokenServiceMock.Setup(t => t.CriarToken(cliente))
                         .Returns(new TokenResponseDto { Token = "JWT" });

        await _service.AuthAsync(dto);

        _repoMock.Verify(r => r.UpdateAsync(cliente), Times.Once);
    }

    #endregion
}
