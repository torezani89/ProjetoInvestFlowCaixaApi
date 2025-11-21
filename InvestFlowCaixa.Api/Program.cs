//using InvestFlowCaixa.Api.Middlewares;
//using InvestFlowCaixa.Api.Swagger;
//using InvestFlowCaixa.Application.DependencyInjection;
//using InvestFlowCaixa.Infrastructure.Data;
//using InvestFlowCaixa.Infrastructure.DependencyInjection;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using Microsoft.OpenApi.Models;
//using System;
//using System.Text;

//var builder = WebApplication.CreateBuilder(args);

//// ############# ADD SERVICES #############

//builder.Services.AddDbContext<InvestimentosDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddControllers();

//builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen();
//// Infrastructure Layer
//builder.Services.AddInfrastructure(builder.Configuration);
////builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
////builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

////Application Layer
//builder.Services.AddApplication();

//// JWT Authentication
//var jwtSettings = builder.Configuration.GetSection("Jwt");
//var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//.AddJwtBearer(options =>
//{
//    options.RequireHttpsMetadata = false; // desative apenas em dev
//    options.SaveToken = true;
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = jwtSettings["Issuer"],
//        ValidAudience = jwtSettings["Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(key)
//    };
//});

//// Swagger e JWT Authentication
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "InvestFlowCaixa API", Version = "v1" });

//    var jwtSecurityScheme = new OpenApiSecurityScheme
//    {
//        Scheme = "bearer",
//        BearerFormat = "JWT",
//        Name = "Authorization",
//        In = ParameterLocation.Header,
//        Type = SecuritySchemeType.Http,
//        Description = "Insira o token JWT gerado pelo login. Exemplo: Bearer {seu_token}",

//        Reference = new OpenApiReference
//        {
//            Id = JwtBearerDefaults.AuthenticationScheme,
//            Type = ReferenceType.SecurityScheme
//        }
//    };

//    c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

//    c.OperationFilter<AddAuthHeaderOperationFilter>();
//});

//builder.Configuration
//    .AddJsonFile("appsettings.json", optional: false)
//    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
//    .AddEnvironmentVariables();

//// ############# BUILD APP #############

//var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<InvestimentosDbContext>();
//    db.Database.Migrate();
//}

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


//app.UseHttpsRedirection();

//app.UseMiddleware<TelemetriaMiddleware>();
//app.UseMiddleware<ErrorHandlingMiddleware>();

//app.UseAuthentication();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

using InvestFlowCaixa.Api.Middlewares;
using InvestFlowCaixa.Api.Swagger;
using InvestFlowCaixa.Application.DependencyInjection;
using InvestFlowCaixa.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ##################### CONFIGURAÇÃO #####################

// Carrega configuração ANTES de adicionar serviços
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) //3º) Local: appsettings.json (default - menor prioridade)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true) //2º) appsettings.{Environment}.json
    .AddEnvironmentVariables(); //1º) Variáveis de ambiente (maior prioridade) -> Docker-compose

// ##################### SERVICES #####################

// DB CONTEXT (usa ENV se estiver no Docker) forçar uso do Docker no dev local
//builder.Services.AddDbContext<InvestimentosDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionDocker")));

builder.Services.AddControllers();

// Swagger + JWT
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "InvestFlowCaixa API",
        Version = "v1",
        Description = "API para simulação investimentos em produtos Caixa",
        Contact = new OpenApiContact
        {
            Name = "Bruno Torezani",
            Email = "torezani89@outlook.com"
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Insira Bearer {seu_token}",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    c.OperationFilter<AddAuthHeaderOperationFilter>();
});

// Infra e Application Layers
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

// JWT Authentication
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});

// ##################### BUILD APP #####################

var app = builder.Build();

// Executa Migrations Automáticas ANTES DE INICIAR A WEB API
//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<InvestimentosDbContext>();
//    db.Database.Migrate();
//}

// ##################### PIPELINE #####################

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<TelemetriaMiddleware>();
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

