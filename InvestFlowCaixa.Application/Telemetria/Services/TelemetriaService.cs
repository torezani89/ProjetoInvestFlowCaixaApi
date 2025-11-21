
using InvestFlowCaixa.Application.Telemetria.Dtos;
using InvestFlowCaixa.Domain.Interfaces;

namespace InvestFlowCaixa.Application.Telemetria.Services
{

    public class TelemetriaService : ITelemetriaService
    {
        private readonly ITelemetriaRepository _repository;

        public TelemetriaService(ITelemetriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<TelemetriaRespostaDto> ObterTelemetriaAsync()
        {
            var inicio = new DateTime(2025, 10, 01);
            var fim = DateTime.Today;

            var dados = await _repository.ObterPorPeriodoAsync(inicio, fim);

            var servicos = dados
                .GroupBy(t => t.NomeServico)
                .Select(g => new TelemetriaServicoDto
                {
                    Nome = g.Key,
                    QuantidadeChamadas = g.Sum(x => x.QuantidadeChamadas),
                    MediaTempoRespostaMs = (int)g.Average(x => x.TempoMedioRespostaMs)
                })
                .ToList();

            return new TelemetriaRespostaDto
            {
                Servicos = servicos,
                Periodo = new TelemetriaPeriodoDto
                {
                    Inicio = inicio,
                    Fim = fim
                }
            };
        }
    }


}
