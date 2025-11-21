using InvestFlowCaixa.Application.Historicos.Services;
using InvestFlowCaixa.Domain.Entities;
using InvestFlowCaixa.Domain.Interfaces;
using Moq;

namespace InvestFlowCaixa.Tests
{
    public class HistoricoInvestimentoServiceTests
    {
        private readonly Mock<IHistoricoInvestimentoRepository> _repoMock;
        private readonly HistoricoInvestimentoService _service;

        public HistoricoInvestimentoServiceTests()
        {
            _repoMock = new Mock<IHistoricoInvestimentoRepository>();

            _service = new HistoricoInvestimentoService(
                _repoMock.Object
            );
        }

        // =====================================================================
        // TESTES - ObterHistoricoAsync
        // =====================================================================

        [Fact]
        public async Task ObterHistoricoAsync_DeveRetornarListaDoRepositorio()
        {
            int clienteId = 10;

            var historicos = new List<HistoricoInvestimento>
            {
                new HistoricoInvestimento
                {
                    Id = 1,
                    ClienteId = clienteId,
                    Tipo = "CDB 6 meses",
                    Valor = 1000,
                    Rentabilidade = 0.10m,
                    Data = DateTime.Today
                },
                new HistoricoInvestimento
                {
                    Id = 2,
                    ClienteId = clienteId,
                    Tipo = "LCI 12 meses",
                    Valor = 5000,
                    Rentabilidade = 0.08m,
                    Data = DateTime.Today
                }
            };

            _repoMock.Setup(r => r.ObterPorClienteAsync(clienteId))
                     .ReturnsAsync(historicos);

            var result = await _service.ObterHistoricoAsync(clienteId);

            Assert.Equal(2, result.Count());
            Assert.Contains(result, x => x.Id == 1);
            Assert.Contains(result, x => x.Id == 2);
        }

        [Fact]
        public async Task ObterHistoricoAsync_DeveRetornarListaVazia_QuandoRepositorioRetornaVazio()
        {
            // Arrange
            int clienteId = 10;

            _repoMock.Setup(r => r.ObterPorClienteAsync(clienteId))
                     .ReturnsAsync(new List<HistoricoInvestimento>());

            // Act
            var result = await _service.ObterHistoricoAsync(clienteId);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public async Task ObterHistoricoAsync_DeveChamarRepositorioComClienteIdCorreto()
        {
            // Arrange
            int clienteId = 10;

            _repoMock.Setup(r => r.ObterPorClienteAsync(clienteId))
                     .ReturnsAsync(new List<HistoricoInvestimento>());

            // Act
            await _service.ObterHistoricoAsync(clienteId);

            // Assert
            _repoMock.Verify(r => r.ObterPorClienteAsync(clienteId), Times.Once);
        }
    }

}
