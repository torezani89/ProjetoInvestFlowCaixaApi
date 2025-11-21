using InvestFlowCaixa.Application.PerfilRisco.Dtos;
using InvestFlowCaixa.Domain.Entities;
using InvestFlowCaixa.Domain.Interfaces;

namespace InvestFlowCaixa.Application.PerfilRisco.Services
{
    public class PerfilRiscoService : IPerfilRiscoService
    {
        private readonly IClienteRepository _clienteRepo;

        public PerfilRiscoService(IClienteRepository clienteRepository, IPerfilRiscoRepository perfilRiscoRepository)
        {
            _clienteRepo = clienteRepository;
        }

        public async Task<PerfilRiscoResponse> ObterPerfilAsync(int clienteId)
        {
            var cliente = await _clienteRepo.ObterClienteComPerfil(clienteId);
            if (cliente == null)
                throw new KeyNotFoundException($"Cliente ID {clienteId} não encontrado.");

            if (cliente.Perfil == null)
                throw new InvalidOperationException($"Cliente ID {clienteId} não possui perfil associado.");

            return new PerfilRiscoResponse
            {
                ClienteId = cliente.Id,
                Perfil = cliente.Perfil.Nome,
                Pontuacao = cliente.Score,
                Descricao = cliente.Perfil.Descricao
            };
        }

        // ------------------------------------------------------------
        //  Análise de Perfil baseado no score total
        // ------------------------------------------------------------
        public (string Nome, string Descricao, int Score) AnalisarPerfil(Cliente cliente)
        {
            int score = CalcularScore(cliente);

            if (score <= 40)
                return ("Conservador", "Baixa movimentação e foco em liquidez.", score);

            if (score <= 70)
                return ("Moderado", "Equilíbrio entre liquidez e rentabilidade.", score);

            return ("Agressivo", "Busca por alta rentabilidade assumindo maior risco.", score);
        }

        // ------------------------------------------------------------
        //  Cálculo simplificado da pontuação
        // ------------------------------------------------------------
        private int CalcularScore(Cliente cliente)
        {
            double volumeScore = CalcularScoreVolume(cliente.VolumeInvestimentos);
            double freqScore = CalcularScoreFrequencia(cliente.FrequenciaMovimentacoes);
            double liquidezScore = (10 - cliente.PreferenciaLiquidez) * 10;
            double rentabScore = cliente.PreferenciaRentabilidade * 10;

            double total =
                volumeScore * 0.35 +
                freqScore * 0.25 +
                liquidezScore * 0.20 +
                rentabScore * 0.20;

            return (int)Math.Round(total);
        }

        private double CalcularScoreVolume(decimal volume)
        {
            if (volume >= 1_000_000) return 100;
            if (volume >= 500_000) return 80;
            if (volume >= 100_000) return 60;
            if (volume >= 50_000) return 40;
            if (volume >= 10_000) return 20;
            return 0;
        }

        private double CalcularScoreFrequencia(int mov)
        {
            if (mov >= 31) return 100;
            if (mov >= 16) return 75;
            if (mov >= 6) return 50;
            if (mov >= 1) return 25;
            return 0;
        }


    }
}
