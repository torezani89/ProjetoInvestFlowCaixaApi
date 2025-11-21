using InvestFlowCaixa.Application.ProdutosInvestimento.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvestFlowCaixa.Api.Controllers
{
    [Route("api/produtos-recomendados")]
    [ApiController]
    public class ProdutosRecomendadosController : ControllerBase
    {
        private readonly IProdutoInvestimentoService _produtoService;

        public ProdutosRecomendadosController(IProdutoInvestimentoService produtoService)
        {
            _produtoService = produtoService;
        }

        /// <summary>
        /// Retorna a lista de produtos recomendados para um perfil de risco específico.
        /// </summary>
        /// <response code="200">Lista de produtos recomendados retornada com sucesso.</response>
        /// <response code="400">PerfilId inválido.</response>
        /// <response code="404">Nenhum produto recomendado encontrado para o perfil informado.</response>
        /// <remarks>
        /// Perfis Id disponíveis:
        /// <pre>
        /// 1 — Conservador: "Baixa movimentação e foco em liquidez."
        /// 2 — Moderado: "Equilíbrio entre liquidez e rentabilidade."
        /// 3 — Agressivo: "Busca por alta rentabilidade assumindo maior risco."
        /// </pre>
        /// Exemplo de resposta:
        /// <pre>
        /// [
        ///   {
        ///     "id": 5,
        ///     "nome": "CDB Banco XP — 12 meses",
        ///     "tipo": "CDB",
        ///     "rentabilidade": 0.121,
        ///     "risco": "Moderado"
        ///   },
        ///   {
        ///     "id": 2,
        ///     "nome": "LCI Caixa — 6 meses",
        ///     "tipo": "LCI",
        ///     "rentabilidade": 0.097,
        ///     "risco": "Baixo"
        ///   }
        /// ]
        /// </pre>
        /// Possíveis erros:
        /// - 400: "PerfilId inválido."  
        /// - 404: "Nenhum produto recomendado encontrado para este perfil."  
        /// </remarks>
        /// <summary>
        /// Retorna os produtos recomendados para um perfil de risco específico.
        /// </summary>
        [HttpGet("{perfilId}")]
        public async Task<IActionResult> GetRecomendados(int perfilId)
        {
            var produtos = await _produtoService.ObterProdutosRecomendadosPorPerfilAsync(perfilId);

            var response = produtos.Select(p => new
            {
                id = p.Id,
                nome = p.Nome,
                tipo = p.Tipo,
                rentabilidade = p.Rentabilidade,
                risco = p.Risco
            });

            return Ok(response);
        }
    }
}
