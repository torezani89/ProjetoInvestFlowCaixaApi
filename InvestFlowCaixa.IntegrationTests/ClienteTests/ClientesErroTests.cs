
//using System.Text;
//using FluentAssertions;
//using InvestFlowCaixa.IntegrationTests.Setup;
//using System.Net;
//using System.Text.Json;


//namespace InvestFlowCaixa.IntegrationTests.ClienteTests
//{

//    public class ClientesErroTests : IClassFixture<TestApiFactory>
//    {
//        private readonly HttpClient _client;
//        private readonly JsonSerializerOptions _opts;

//        public ClientesErroTests(TestApiFactory factory)
//        {
//            _client = factory.CreateClient();

//            _opts = new JsonSerializerOptions
//            {
//                PropertyNameCaseInsensitive = true
//            };
//        }

//        // ================================
//        // 1. GET /clientes/{id} - inexistente
//        // ================================
//        [Fact]
//        public async Task Get_Inexistente_DeveRetornar404()
//        {
//            var response = await _client.GetAsync("/api/clientes/999");

//            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

//            var json = await response.Content.ReadAsStringAsync();
//            var erro = JsonSerializer.Deserialize<ErrorResponseTeste>(json, _opts);

//            erro.Sucesso.Should().BeFalse();
//            erro.StatusCode.Should().Be(404);
//            erro.Mensagem.Should().Contain("não encontrado");
//            erro.Caminho.Should().Be("/api/clientes/999");
//        }

//        // ================================
//        // 2. DELETE /clientes/{id} - inexistente
//        // ================================
//        [Fact]
//        public async Task Delete_Inexistente_DeveRetornar404()
//        {
//            var response = await _client.DeleteAsync("/api/clientes/999");

//            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

//            var json = await response.Content.ReadAsStringAsync();
//            var erro = JsonSerializer.Deserialize<ErrorResponseTeste>(json, _opts);

//            erro.StatusCode.Should().Be(404);
//        }

//        // ================================
//        // 3. PUT /clientes/{id} - inexistente
//        // ================================
//        [Fact]
//        public async Task Put_Inexistente_DeveRetornar404()
//        {
//            var payload = new
//            {
//                nome = "Teste",
//                rendaMensal = 5000
//            };

//            var json = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

//            var response = await _client.PutAsync("/api/clientes/999", json);

//            response.StatusCode.Should().Be(HttpStatusCode.NotFound);

//            var body = await response.Content.ReadAsStringAsync();
//            var erro = JsonSerializer.Deserialize<ErrorResponseTeste>(body, _opts);

//            erro.StatusCode.Should().Be(404);
//        }

//        // ================================
//        // 4. POST com CPF duplicado
//        // ================================
//        [Fact]
//        public async Task Post_CpfDuplicado_DeveRetornar400()
//        {
//            var cliente = new
//            {
//                nome = "Cliente 1",
//                cpf = "12345678901",
//                rendaMensal = 1000m,
//                volumeInvestimentos = 10m,
//                frequenciaMovimentacoes = 1,
//                preferenciaLiquidez = 5,
//                preferenciaRentabilidade = 5,
//                senha = "Teste123",
//                confirmaSenha = "Teste123"
//            };

//            var json = JsonSerializer.Serialize(cliente);
//            var content = new StringContent(json, Encoding.UTF8, "application/json");

//            // cria o primeiro
//            var resp1 = await _client.PostAsync("/api/clientes", content);
//            resp1.StatusCode.Should().Be(HttpStatusCode.Created);

//            // tenta criar novamente com o mesmo CPF
//            var resp2 = await _client.PostAsync("/api/clientes", content);

//            resp2.StatusCode.Should().Be(HttpStatusCode.BadRequest);

//            var body = await resp2.Content.ReadAsStringAsync();
//            var erro = JsonSerializer.Deserialize<ErrorResponseTeste>(body, _opts);

//            erro.StatusCode.Should().Be(400);
//            erro.Mensagem.Should().Contain("já existe");
//        }

//        // ================================
//        // 5. POST com ModelState inválido
//        // ================================
//        [Fact]
//        public async Task Post_ModelStateInvalido_DeveRetornar400()
//        {
//            var cliente = new
//            {
//                nome = "",              // inválido
//                cpf = "123",            // inválido
//                rendaMensal = -10,      // inválido
//                volumeInvestimentos = 0,
//                frequenciaMovimentacoes = 0,
//                preferenciaLiquidez = 10,
//                preferenciaRentabilidade = 10,
//                senha = "123",
//                confirmaSenha = "123"
//            };

//            var json = JsonSerializer.Serialize(cliente);
//            var content = new StringContent(json, Encoding.UTF8, "application/json");

//            var resp = await _client.PostAsync("/api/clientes", content);

//            resp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
//        }

//        // ================================
//        // 6. POST com senhas diferentes
//        // ================================
//        [Fact]
//        public async Task Post_SenhasDiferentes_DeveRetornar400()
//        {
//            var cliente = new
//            {
//                nome = "Teste",
//                cpf = "98765432100",
//                rendaMensal = 1000m,
//                volumeInvestimentos = 100m,
//                frequenciaMovimentacoes = 1,
//                preferenciaLiquidez = 5,
//                preferenciaRentabilidade = 6,
//                senha = "abc123",
//                confirmaSenha = "outraSenha"       // inválida
//            };

//            var json = JsonSerializer.Serialize(cliente);
//            var content = new StringContent(json, Encoding.UTF8, "application/json");

//            var resp = await _client.PostAsync("/api/clientes", content);

//            resp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
//        }

//        // -------------------------
//        // Modelo interno para erro
//        // -------------------------
//        private class ErrorResponseTeste
//        {
//            public bool Sucesso { get; set; }
//            public int StatusCode { get; set; }
//            public string Mensagem { get; set; }
//            public string Detalhes { get; set; }
//            public string Caminho { get; set; }
//        }
//    }

//}
