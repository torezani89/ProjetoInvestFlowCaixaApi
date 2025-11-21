using InvestFlowCaixa.Domain.Entities;
using System.Net;
using System.Text.Json;

namespace InvestFlowCaixa.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {

                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, "Erro não tratado: {Mensagem}", ex.Message);

            context.Response.ContentType = "application/json";

            var statusCode = ex switch // Mapeamento de status HTTP
            {
                ArgumentException => (int)HttpStatusCode.BadRequest, //400 (entrada inválida)
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized, //401 (acesso não autorizado)
                KeyNotFoundException => (int)HttpStatusCode.NotFound, //404 (não encontrado)
                _ => (int)HttpStatusCode.InternalServerError //500 (erro interno), se não for nenhum dos anteriores
            };

            context.Response.StatusCode = statusCode;

            var env = context.RequestServices.GetRequiredService<IWebHostEnvironment>();

            var detalhes = env.IsDevelopment() ? ex.InnerException?.Message : "Erro interno no servidor";

            var response = new ErrorResponse
            {
                Sucesso = false,
                StatusCode = statusCode,
                Mensagem = ex.Message,
                Detalhes = detalhes,
                Caminho = context.Request.Path 
            };

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

    
            await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
        }
    }
}
