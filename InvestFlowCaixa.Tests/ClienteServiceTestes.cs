using AutoMapper;
using InvestFlowCaixa.Application.Clientes.Dtos;
using InvestFlowCaixa.Application.Clientes.Services;
using InvestFlowCaixa.Application.PerfilRisco.Services;
using InvestFlowCaixa.Domain.Entities;
using InvestFlowCaixa.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System.Linq.Expressions;
using Xunit;

namespace InvestFlowCaixa.Tests
{

    public class ClienteServiceTests
    {
        private readonly Mock<IClienteRepository> _repoMock;
        private readonly Mock<ISenhaService> _senhaServiceMock;
        private readonly Mock<ITokenService> _tokenServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<ClienteService>> _loggerMock;
        private readonly Mock<IPerfilRiscoRepository> _perfilRiscoRepoMock;
        private readonly Mock<IPerfilRiscoService> _perfilRiscoServiceMock;

        private readonly ClienteService _service;

        public ClienteServiceTests()
        {
            _repoMock = new Mock<IClienteRepository>();
            _senhaServiceMock = new Mock<ISenhaService>();
            _tokenServiceMock = new Mock<ITokenService>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<ClienteService>>();
            _perfilRiscoRepoMock = new Mock<IPerfilRiscoRepository>();
            _perfilRiscoServiceMock = new Mock<IPerfilRiscoService>();

            _service = new ClienteService(
                _repoMock.Object,
                _perfilRiscoRepoMock.Object,
                _perfilRiscoServiceMock.Object,
                _senhaServiceMock.Object,
                _loggerMock.Object,
                _mapperMock.Object
            );
        }

        private ClienteCriacaoDto CriarDtoValido()
        {
            return new ClienteCriacaoDto
            {
                Nome = "João",
                CPF = "12345678901",
                RendaMensal = 5000,
                VolumeInvestimentos = 10000,
                FrequenciaMovimentacoes = 5,
                PreferenciaLiquidez = 3,
                PreferenciaRentabilidade = 7,
                Senha = "abc",
                ConfirmaSenha = "abc"
            };
        }

        private Cliente CriarClienteBase()
        {
            return new Cliente
            {
                Id = 10,
                Nome = "Teste",
                RendaMensal = 3000,
                VolumeInvestimentos = 5000,
                FrequenciaMovimentacoes = 5,
                PreferenciaLiquidez = 5,
                PreferenciaRentabilidade = 5,
                PerfilId = 1,
                Perfil = new PerfilRisco { Nome = "Moderado" }
            };
        }

        // ----------------------------------------------------------------------
        #region Validations
        // ----------------------------------------------------------------------

        [Fact]
        public async Task CriarAsync_DeveFalhar_QuandoCpfJaExiste()
        {
            var dto = CriarDtoValido();

            _repoMock.Setup(r => r.ExisteAsync(It.IsAny<Expression<Func<Cliente, bool>>>()))
                     .ReturnsAsync(true);

            await Assert.ThrowsAsync<ArgumentException>(() => _service.CriarAsync(dto));
        }

        [Fact]
        public async Task CriarAsync_DeveFalhar_QuandoNomeVazio()
        {
            var dto = CriarDtoValido();
            dto.Nome = "   ";

            _repoMock.Setup(r => r.ExisteAsync(It.IsAny<Expression<Func<Cliente, bool>>>()))
                     .ReturnsAsync(false);

            await Assert.ThrowsAsync<ArgumentException>(() => _service.CriarAsync(dto));
        }

        [Fact]
        public async Task CriarAsync_DeveFalhar_QuandoRendaMensalNegativa()
        {
            var dto = CriarDtoValido();
            dto.RendaMensal = -100;

            _repoMock.Setup(r => r.ExisteAsync(It.IsAny<Expression<Func<Cliente, bool>>>()))
                     .ReturnsAsync(false);

            await Assert.ThrowsAsync<ArgumentException>(() => _service.CriarAsync(dto));
        }

        #endregion

        // ----------------------------------------------------------------------
        #region Dependencies
        // ----------------------------------------------------------------------

        [Fact]
        public async Task CriarAsync_DeveChamarCriarSenhaHash()
        {
            var dto = CriarDtoValido();

            _repoMock.Setup(r => r.ExisteAsync(It.IsAny<Expression<Func<Cliente, bool>>>()))
                     .ReturnsAsync(false);

            _mapperMock.Setup(m => m.Map<Cliente>(It.IsAny<ClienteCriacaoDto>()))
                       .Returns(new Cliente
                       {
                           VolumeInvestimentos = dto.VolumeInvestimentos,
                           FrequenciaMovimentacoes = dto.FrequenciaMovimentacoes,
                           PreferenciaLiquidez = dto.PreferenciaLiquidez,
                           PreferenciaRentabilidade = dto.PreferenciaRentabilidade
                       });

            _mapperMock.Setup(m => m.Map<ClienteRespostaDto>(It.IsAny<Cliente>()))
           .Returns(new ClienteRespostaDto());

            _perfilRiscoRepoMock
                .Setup(r => r.ObterPerfilIdPorNomeAsync(It.IsAny<string>()))
                .ReturnsAsync(2);

            _repoMock.Setup(r => r.AddAsync(It.IsAny<Cliente>()))
                     .Returns(Task.CompletedTask);

            await _service.CriarAsync(dto);

            _senhaServiceMock.Verify(s => s.CriarSenhaHash(
                dto.Senha,
                out It.Ref<byte[]>.IsAny,
                out It.Ref<byte[]>.IsAny
            ), Times.Once);
        }

        #endregion

        // ----------------------------------------------------------------------
        #region Success
        // ----------------------------------------------------------------------

        [Fact]
        public async Task CriarAsync_DeveCriarClienteComSucesso()
        {
            var dto = CriarDtoValido();

            var cliente = new Cliente
            {
                Id = 10
            };

            _repoMock.Setup(r => r.ExisteAsync(It.IsAny<Expression<Func<Cliente, bool>>>()))
                     .ReturnsAsync(false);

            _mapperMock.Setup(m => m.Map<Cliente>(dto))
                       .Returns(cliente);

            // retorna uma tupla, como o serviço real
            _perfilRiscoServiceMock
                .Setup(s => s.AnalisarPerfil(It.IsAny<Cliente>()))
                .Returns(("Moderado", "Perfil moderado de teste", 50));

            _perfilRiscoRepoMock
                .Setup(r => r.ObterPerfilIdPorNomeAsync("Moderado"))
                .ReturnsAsync(2);

            _repoMock.Setup(r => r.AddAsync(cliente))
                     .Returns(Task.CompletedTask);

            _mapperMock.Setup(m => m.Map<ClienteRespostaDto>(cliente))
                       .Returns(new ClienteRespostaDto { Id = 10 });

            var result = await _service.CriarAsync(dto);

            Assert.Equal(10, result.Id);
            Assert.Equal("Moderado", result.PerfilTipo); // agora OK!
        }

        #endregion

        // ====================================================================
        // ATUALIZARASYNC
        // ====================================================================

        #region Atualizar - Validations

        [Fact]
        public async Task AtualizarAsync_DeveFalhar_QuandoClienteNaoExiste()
        {
            _repoMock.Setup(r => r.ObterClienteComPerfil(10))
                     .ReturnsAsync((Cliente?)null);

            var dto = new ClienteAtualizacaoDto
            {
                Nome = "Teste",
                RendaMensal = 6000
            };

            await Assert.ThrowsAsync<KeyNotFoundException>(() => _service.AtualizarAsync(10, dto));
        }

        #endregion


        #region Atualizar - Campos alterados sem reanalisar perfil

        [Fact]
        public async Task AtualizarAsync_DeveAtualizarApenasNomeESalvar_SemReanalisarPerfil()
        {
            var cliente = CriarClienteBase();

            var dto = new ClienteAtualizacaoDto
            {
                Nome = "Novo Nome",
                VolumeInvestimentos = null,          // garantir que esses campos não acionem reanálise
                FrequenciaMovimentacoes = null,
                PreferenciaLiquidez = null,
                PreferenciaRentabilidade = null
            };

            _repoMock.Setup(r => r.ObterClienteComPerfil(10)).ReturnsAsync(cliente);
            _repoMock.Setup(r => r.UpdateAsync(cliente)).Returns(Task.CompletedTask);

            _mapperMock.Setup(m => m.Map<ClienteRespostaDto>(cliente))
                       .Returns(new ClienteRespostaDto { Id = 10, Nome = "Novo" });

            var result = await _service.AtualizarAsync(10, dto);

            Assert.Equal("Novo Nome", cliente.Nome);
            Assert.Equal("Moderado", result.PerfilTipo); // perfil anterior mantido

            _perfilRiscoRepoMock.Verify(r => r.ObterPerfilIdPorNomeAsync(It.IsAny<string>()), Times.Never);
        }

        #endregion


        #region Atualizar - Reanalisar perfil se Volume/Frequencia/Liquidez/Rentabilidade mudam

        [Fact]
        public async Task AtualizarAsync_DeveReanalisarPerfil_QuandoVolumeInvestimentosAlterado()
        {
            var cliente = CriarClienteBase();

            var dto = new ClienteAtualizacaoDto
            {
                VolumeInvestimentos = 100000  // MUDA, deve recalcular perfil
            };

            _repoMock.Setup(r => r.ObterClienteComPerfil(10)).ReturnsAsync(cliente);

            _perfilRiscoRepoMock
                .Setup(r => r.ObterPerfilIdPorNomeAsync(It.IsAny<string>()))
                .ReturnsAsync(2);

            _repoMock.Setup(r => r.UpdateAsync(cliente)).Returns(Task.CompletedTask);

            _mapperMock.Setup(m => m.Map<ClienteRespostaDto>(cliente))
                       .Returns(new ClienteRespostaDto { Id = 10 });

            var result = await _service.AtualizarAsync(10, dto);

            Assert.NotEqual(1, cliente.PerfilId); // mudou
            Assert.False(string.IsNullOrWhiteSpace(result.PerfilTipo));

            _perfilRiscoRepoMock.Verify(r => r.ObterPerfilIdPorNomeAsync(It.IsAny<string>()), Times.Once);
        }

        #endregion


        #region Atualizar - Reanalisar perfil se preferências mudam

        [Fact]
        public async Task AtualizarAsync_DeveReanalisarPerfil_QuandoPreferenciasMudam()
        {
            var cliente = CriarClienteBase();

            var dto = new ClienteAtualizacaoDto
            {
                PreferenciaLiquidez = 1,
                PreferenciaRentabilidade = 10
            };

            _repoMock.Setup(r => r.ObterClienteComPerfil(10)).ReturnsAsync(cliente);

            _perfilRiscoRepoMock
                .Setup(r => r.ObterPerfilIdPorNomeAsync(It.IsAny<string>()))
                .ReturnsAsync(3);

            _repoMock.Setup(r => r.UpdateAsync(cliente)).Returns(Task.CompletedTask);

            _mapperMock.Setup(m => m.Map<ClienteRespostaDto>(cliente))
                       .Returns(new ClienteRespostaDto { Id = 10 });

            var result = await _service.AtualizarAsync(10, dto);

            Assert.NotEqual(1, cliente.PerfilId);
            Assert.False(string.IsNullOrWhiteSpace(result.PerfilTipo));

            _perfilRiscoRepoMock.Verify(r => r.ObterPerfilIdPorNomeAsync(It.IsAny<string>()), Times.Once);
        }

        #endregion


        #region Atualizar - Sucesso

        [Fact]
        public async Task AtualizarAsync_DeveAtualizarClienteComSucesso()
        {
            var cliente = new Cliente
            {
                Id = 10,
                Nome = "Antigo",
                RendaMensal = 3000,
                VolumeInvestimentos = 10000,
                FrequenciaMovimentacoes = 5,
                PreferenciaLiquidez = 4,
                PreferenciaRentabilidade = 6,
                PerfilId = 1,
                Perfil = new PerfilRisco { Nome = "Moderado" }
            };

            var dto = new ClienteAtualizacaoDto
            {
                Nome = "Novo",
                RendaMensal = 4000
            };

            _repoMock.Setup(r => r.ObterClienteComPerfil(10)).ReturnsAsync(cliente);
            _repoMock.Setup(r => r.UpdateAsync(cliente)).Returns(Task.CompletedTask);

            _mapperMock.Setup(m => m.Map<ClienteRespostaDto>(cliente))
                       .Returns(new ClienteRespostaDto { Id = 10, Nome = "Novo", PerfilTipo = "Moderado" });

            var result = await _service.AtualizarAsync(10, dto);

            Assert.Equal("Novo", result.Nome);
            Assert.Equal(4000, cliente.RendaMensal);
            Assert.Equal("Moderado", result.PerfilTipo); // deve manter o mesmo perfil
            _repoMock.Verify(r => r.UpdateAsync(cliente), Times.Once);
        }

        #endregion

    }


}