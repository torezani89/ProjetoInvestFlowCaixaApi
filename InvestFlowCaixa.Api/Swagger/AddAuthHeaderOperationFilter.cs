using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace InvestFlowCaixa.Api.Swagger
{

    public class AddAuthHeaderOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Verifica se o endpoint tem o atributo [Authorize]
            var hasAuthorize = context.MethodInfo
                .GetCustomAttributes(true)
                .OfType<AuthorizeAttribute>()
                .Any()
                ||
                context.MethodInfo.DeclaringType
                .GetCustomAttributes(true)
                .OfType<AuthorizeAttribute>()
                .Any();

            if (!hasAuthorize)
                return;

            // Adiciona o cadeado apenas a rotas com [Authorize]
            operation.Security = new List<OpenApiSecurityRequirement>
        {
            new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new List<string>()
                }
            }
        };
        }
    }
}
