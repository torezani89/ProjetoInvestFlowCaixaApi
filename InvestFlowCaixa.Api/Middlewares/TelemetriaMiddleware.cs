using InvestFlowCaixa.Domain.Entities;
using InvestFlowCaixa.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InvestFlowCaixa.Api.Middlewares
{
    public class TelemetriaMiddleware
    {
        private readonly RequestDelegate _next;

        public TelemetriaMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, InvestimentosDbContext db)
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            await _next(context);

            stopwatch.Stop();

            var caminho = context.Request.Path.Value?.ToLower();

            if (caminho.Contains("simular-investimento") ||
                caminho.Contains("perfil-risco"))
            {
                var nomeServico = caminho.Contains("simular-investimento")
                    ? "simular-investimento"
                    : "perfil-risco";

                var registro = await db.TelemetriaServicos
                    .FirstOrDefaultAsync(t =>
                        t.NomeServico == nomeServico &&
                        t.DataReferencia.Date == DateTime.Today);

                if (registro is null)
                {
                    registro = new TelemetriaServico
                    {
                        NomeServico = nomeServico,
                        QuantidadeChamadas = 1,
                        TempoMedioRespostaMs = stopwatch.ElapsedMilliseconds is > int.MaxValue
                            ? int.MaxValue
                            : (int)stopwatch.ElapsedMilliseconds,
                        DataReferencia = DateTime.Today
                    };

                    db.TelemetriaServicos.Add(registro);
                }
                else
                {
                    // média incremental simples
                    registro.QuantidadeChamadas++;
                    registro.TempoMedioRespostaMs =
                        (registro.TempoMedioRespostaMs + (int)stopwatch.ElapsedMilliseconds) / 2;
                }

                await db.SaveChangesAsync();
            }
        }
    }

}
