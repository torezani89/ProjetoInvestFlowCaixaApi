# ProjetoInvestFlowCaixaApi

Aqui está um **README.md** simples, direto e adequado para testar a API **InvestFlowCaixa.Api**.
Se quiser, posso gerar também a versão em inglês ou mais detalhada.

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
 ├─ InvestFlowCaixa.Application/   → Regras de negócio / UseCases
 ├─ InvestFlowCaixa.Domain/        → Entidades e interfaces
 ├─ InvestFlowCaixa.Infrastructure/→ Repositórios e EF Core
 └─ InvestFlowCaixa.Tests/         → Testes unitários e integração
```

---

## 🛠 Pré-requisitos

Antes de rodar o projeto, instale:

* ✔️ **.NET SDK 8**
* ✔️ **SQL Server** (local)
* ✔️ **Visual Studio / VSCode** (opcional)

---

## 🗄 Configurando a Base de Dados

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

---

## Como executar a API

```bash
dotnet run --project InvestFlowCaixa.Api
```

A API iniciará em:

* **[https://localhost:7226](https://localhost:7226)**
* **[http://localhost:5226](http://localhost:5226)**

---

## 📘 Testando via Swagger

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

## 📈 Endpoints Principais

### 📍 Clientes

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

### 📍 Histórico de Investimentos

```
GET /investimentos/{clienteId}
```

### Telemetria

```
GET /telemetria
```

---

## Autenticação

Enviar JWT no header: colar apenas o <token>, não escrever "Bearer".
```
Authorization: Bearer <token>
```

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
