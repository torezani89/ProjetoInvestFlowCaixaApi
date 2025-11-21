# ProjetoInvestFlowCaixaApi

link do repositório público: https://github.com/torezani89/ProjetoInvestFlowCaixaApi

---

# InvestFlowCaixa.Api — README

API do projeto **InvestFlowCaixa**, responsável por gerenciar clientes, investimentos, simulações e telemetria.
Este guia explica como **executar**, **configurar** e **testar** a API localmente.

---

## Tecnologias utilizadas

* **.NET 8**
* **ASP.NET Core Web API**
* **Entity Framework Core**
* **SQL Server**
* **Swagger / Swashbuckle**
* **xUnit + Moq** (testes)
* **Autenticação JWT**

---

## Estrutura do Projeto

```
InvestFlowCaixa/
 ├─ InvestFlowCaixa.Api/           → Camada de API
 ├─ InvestFlowCaixa.Application/   → Regras de negócio
 ├─ InvestFlowCaixa.Domain/        → Entidades e interfaces
 ├─ InvestFlowCaixa.Infrastructure/→ Repositórios e EF Core
 └─ InvestFlowCaixa.Tests/         → Testes unitários
```

---

## Pré-requisitos

Antes de rodar o projeto, instale:

* **.NET SDK 8**
* **SQL Server** (local)
* **Visual Studio / VSCode** (opcional)

---

## Configurando a Base de Dados

No *appsettings.json* da API, configure sua connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=DESKTOP-P97U87L\\SQLEXPRESS;Database=InvestFlowCaixa;Trusted_Connection=True;TrustServerCertificate=True"
}
```

Rodar migrations:

```bash
cd InvestFlowCaixa.Api
dotnet ef database update
```

Se a aplicação estiver rodando em containers Docker, ajuste a connection string em *docker-compose.yaml* para apontar para o serviço do banco de dados.

```
      # Modelo de Connection string para sobrescrever a do appsettings.json:
      ConnectionStrings__DefaultConnection: "Server=host.docker.internal;Database=InvestFlowCaixaDb;User Id=sa;Password=SenhaForte123;TrustServerCertificate=True;"

      # Modelo de connection string para usar com SQL Server rodando em container Docker:
      ConnectionStrings__DefaultConnection: "Server=sqlserver,1433;Database=InvestFlowCaixaDb;User Id=sa;Password=SenhaForte123!;TrustServerCertificate=True;"
```
---

## Como executar a API

```bash
dotnet run --project InvestFlowCaixa.Api
```

A API iniciará em:

* **[https://localhost:7226](https://localhost:7226)**
* **[http://localhost:5057](http://localhost:5057)**

---

## Testando via Swagger

Com a API rodando, abra no navegador:

```
https://localhost:7226/swagger
```

Aqui é possível testar todos os endpoints, incluindo:

* **Clientes**
* **Simulações**
* **Investimentos**
* **Telemetria**

Se algum endpoint exigir **JWT**, o Swagger exibirá um ícone de cadeado 🔒.

---

## Endpoints Principais

### Clientes

```
POST /api/clientes
GET  /api/clientes/{id}
PUT  /api/clientes/{id}
DELETE /api/clientes/{id}
```

### Simulação de Investimentos

```
POST /api/simulacoes
GET  /api/simulacoes/{id}
```

### Histórico de Investimentos

```
GET /investimentos/{clienteId}
```

### Telemetria

```
GET /telemetria
```

---

## Autenticação

Enviar JWT no header:
- Por se tratar de um projeto de teste, a autenticação foi aplicada apenas a algumas rotas, com o objetivo de facilitar o uso e a navegação pela API.
- Logar através da rota "/api/Auth/autenticar" para gerar o token na reposta da requisição.
- Utilize dados dos clientes criados via seed para fazer o login.
```
{
"cpf": "11111111111",
"senha": "123"
}
``` 

- Outros CPFs para teste: 22222222222, 33333333333. A senha também é 123.

```
Authorization: Bearer <token>

```
OBS: Colar apenas o token no autenticador, não é necessário escrever a palavra "Bearer".

---


## Contribuição

Pull Requests são bem-vindos!
Padronize sempre com:

* Clean Code
* CQRS na camada Application
* Repositórios na camada Infrastructure

---

## 📄 Licença

Projeto interno — uso restrito.

---
