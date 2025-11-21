using InvestFlowCaixa.Application.Clientes.Dtos;
using InvestFlowCaixa.Application.Clientes.Services;
using Microsoft.AspNetCore.Mvc;

namespace InvestFlowCaixa.Api.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(IClienteService service, ILogger<ClientesController> logger)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Retorna dados de um cliente específico passando o id como parâmetro.
        /// </summary>
        /// <response code="200">Retorna os dados do cliente solicitado.</response>
        /// <response code="404">Cliente não encontrado.</response>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
                var cliente = await _service.ObterPorIdAsync(id);
                return Ok(cliente);
        }

        /// <summary>
        /// Cria um novo cliente com os dados fornecidos no corpo da requisição.
        /// </summary>
        /// <response code="201">Cliente criado com sucesso.</response>
        /// <response code="400">
        /// Erros de validação, tais como:
        /// - CPF já existente  
        /// - Nome obrigatório  
        /// - Renda mensal negativa  
        /// </response>
        /// <remarks>
        /// Exemplo de request (POST api/clientes):
        /// <pre>
        /// {
        ///   "nome": "Cesar Viana",
        ///   "cpf": "46739135648",
        ///   "rendaMensal": 15000,
        ///   "volumeInvestimentos": 4000000,
        ///   "frequenciaMovimentacoes": 16,
        ///   "preferenciaLiquidez": 8,
        ///   "preferenciaRentabilidade": 3,
        ///   "senha": "123",
        ///   "confirmaSenha": "123"
        /// }
        /// </pre>
        ///
        /// Exemplo de resposta:
        /// <pre>
        /// {
        ///   "id": 10,
        ///   "nome": "Cesar Viana",
        ///   "cpf": "46739135648",
        ///   "rendaMensal": 15000,
        ///   "volumeInvestimentos": 4000000,
        ///   "frequenciaMovimentacoes": 16,
        ///   "preferenciaLiquidez": 8,
        ///   "preferenciaRentabilidade": 3,
        ///   "score": 72,
        ///   "perfilTipo": "Moderado"
        /// }
        /// </pre>
        ///
        /// Possíveis erros:
        /// - 400: "Cliente com CPF já existe."  
        /// - 400: "Nome do cliente é obrigatório."  
        /// - 400: "Renda mensal não pode ser negativa."  
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] ClienteCriacaoDto dto)
        {
                var resultado = await _service.CriarAsync(dto);
                return CreatedAtAction(nameof(ObterPorId), new { id = resultado.Id }, resultado);
        }

        /// <summary>
        /// Atualiza os dados de um cliente existente.
        /// </summary>
        /// <response code="200">Cliente atualizado com sucesso.</response>
        /// <response code="404">Cliente não encontrado.</response>
        /// <remarks>
        /// Enviar apenas os campos que deseja alterar.
        ///
        /// Exemplo de request (PUT api/clientes/{id}):
        /// <pre>
        /// {
        ///   "nome": "Novo Nome",
        ///   "rendaMensal": 18000,
        ///   "frequenciaMovimentacoes": 20
        /// }
        /// </pre>
        ///
        /// Possíveis erros:
        /// - 404: "Cliente com ID X não encontrado."  
        /// </remarks>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] ClienteAtualizacaoDto dto)
        {
                var atualizado = await _service.AtualizarAsync(id, dto);
                return Ok(atualizado);
        }

        /// <summary>
        /// Remove um cliente existente.
        /// </summary>
        /// <response code="204">Cliente removido com sucesso.</response>
        /// <response code="404">Cliente não encontrado.</response>
        /// <remarks>
        /// Possíveis erros:
        /// - 404: "Cliente com ID X não encontrado."
        /// </remarks>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remover(int id)
        {
                await _service.RemoverAsync(id);
                return NoContent();
        }
    }
}
