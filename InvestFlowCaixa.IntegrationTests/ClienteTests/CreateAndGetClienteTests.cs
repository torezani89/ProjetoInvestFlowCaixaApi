//using FluentAssertions;
//using InvestFlowCaixa.IntegrationTests.Setup;
//using System.Net;
//using System.Text;
//using System.Text.Json;

//namespace InvestFlowCaixa.IntegrationTests.ClienteTests
//{
//    public class CreateAndGetClienteTests : IClassFixture<TestApiFactory>
//    {
//        private readonly HttpClient _client;

//        public CreateAndGetClienteTests(TestApiFactory factory)
//        {
//            _client = factory.CreateClient();
//        }

//        [Fact]
//        public async Task PostCliente_Then_GetCliente_Should_Create_And_Return_Cliente()
//        {
//            // Arrange — payload EXACTO do ClienteCriacaoDto
//            var novoCliente = new
//            {
//                nome = "João da Silva",
//                cpf = "12345678901",
//                rendaMensal = 7500m,
//                volumeInvestimentos = 20000m,
//                frequenciaMovimentacoes = 10,
//                preferenciaLiquidez = 7,
//                preferenciaRentabilidade = 6,
//                senha = "SenhaForte123",
//                confirmaSenha = "SenhaForte123"
//            };

//            var json = JsonSerializer.Serialize(novoCliente);
//            var content = new StringContent(json, Encoding.UTF8, "application/json");

//            // Act — criar cliente
//            var postResponse = await _client.PostAsync("/api/clientes", content);

//            // Assert — criação deve retornar 201
//            postResponse.StatusCode.Should().Be(HttpStatusCode.Created);

//            // Ler body do POST
//            var bodyPost = await postResponse.Content.ReadAsStringAsync();

//            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
//            var clienteCriado = JsonSerializer.Deserialize<ClienteResposta>(bodyPost, options);

//            clienteCriado.Should().NotBeNull();
//            clienteCriado.Id.Should().BeGreaterThan(0);
//            clienteCriado.Nome.Should().Be("João da Silva");
//            clienteCriado.CPF.Should().Be("12345678901");

//            // Act — buscar o cliente recém-criado
//            var getResponse = await _client.GetAsync($"/api/clientes/{clienteCriado.Id}");

//            getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

//            var bodyGet = await getResponse.Content.ReadAsStringAsync();
//            var clienteBuscado = JsonSerializer.Deserialize<ClienteResposta>(bodyGet, options);

//            // Assert — dados retornados devem ser iguais aos enviados
//            clienteBuscado.Should().NotBeNull();
//            clienteBuscado.Nome.Should().Be("João da Silva");
//            clienteBuscado.CPF.Should().Be("12345678901");
//            clienteBuscado.RendaMensal.Should().Be(7500m);
//            clienteBuscado.VolumeInvestimentos.Should().Be(20000m);
//            clienteBuscado.FrequenciaMovimentacoes.Should().Be(10);
//            clienteBuscado.PreferenciaLiquidez.Should().Be(7);
//            clienteBuscado.PreferenciaRentabilidade.Should().Be(6);

//            // Score e PerfilTipo são definidos internamente no service
//            clienteBuscado.Score.Should().BeGreaterThan(0);
//            clienteBuscado.PerfilTipo.Should().NotBeNullOrEmpty();
//        }

//        // DTO interno do teste para mapear a resposta
//        private class ClienteResposta
//        {
//            public int Id { get; set; }
//            public string Nome { get; set; }
//            public string CPF { get; set; }
//            public decimal RendaMensal { get; set; }
//            public decimal VolumeInvestimentos { get; set; }
//            public int FrequenciaMovimentacoes { get; set; }
//            public int PreferenciaLiquidez { get; set; }
//            public int PreferenciaRentabilidade { get; set; }
//            public int Score { get; set; }
//            public string PerfilTipo { get; set; }
//        }
//    }

//}
