using InvestFlowCaixa.Domain.Entities;
using InvestFlowCaixa.Domain.Interfaces;

namespace InvestFlowCaixa.Application.ProdutosInvestimento.Services
{
    public class ProdutoInvestimentoService : IProdutoInvestimentoService
    {
        private readonly IProdutoInvestimentoRepository _produtoRepo;
        private readonly IPerfilRiscoRepository _perfilRiscoRepo;

        public ProdutoInvestimentoService(IProdutoInvestimentoRepository produtoRepo, IPerfilRiscoRepository perfilRiscoRepo)
        {
            _produtoRepo = produtoRepo;
            _perfilRiscoRepo = perfilRiscoRepo;
        }

        public async Task<IEnumerable<ProdutoInvestimento>> ObterProdutosDoTipoAsync(string tipo)
        {
            return await _produtoRepo.GetByTipoAsync(tipo);
        }


        public List<string> ObterRiscosPermitidos(string perfilCliente)
        {
            return perfilCliente switch
            {
                "Conservador" => new List<string> { "Baixo" },
                "Moderado" => new List<string> { "Baixo", "Moderado" },
                "Agressivo" => new List<string> { "Baixo", "Moderado", "Alto" },
                _ => new List<string>()
            };
        }

        public List<ProdutoInvestimento> FiltrarElegiveis(IEnumerable<ProdutoInvestimento> produtos, decimal valor, int prazoMeses)
        {
            return produtos
                .Where(p => valor >= p.MinValor)
                .Where(p => prazoMeses <= p.MaxPrazoMeses)
                .ToList();
        }

        public ProdutoInvestimento SelecionarMelhorProduto(List<ProdutoInvestimento> elegiveis, string perfilCliente)
        {
            var niveis = new List<string> { "Baixo", "Moderado", "Alto" };

            string riscoCliente = perfilCliente switch
            {
                "Conservador" => "Baixo",
                "Moderado" => "Moderado",
                "Agressivo" => "Alto",
                _ => "Baixo"
            };

            int idxCliente = niveis.IndexOf(riscoCliente);

            // 1. Primeiro, tenta localizar produto no nível de risco do cliente
            var noNivelCliente = elegiveis
                .Where(p => p.Risco.Equals(niveis[idxCliente], StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (noNivelCliente.Any())
                return noNivelCliente.OrderByDescending(p => p.Rentabilidade).First();

            // 2. Se não localizar, desce níveis gradualmente
            for (int i = idxCliente - 1; i >= 0; i--)
            {
                var nivelInferior = elegiveis
                    .Where(p => p.Risco.Equals(niveis[i], StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (nivelInferior.Any())
                    return nivelInferior.OrderByDescending(p => p.Rentabilidade).First();
            }

            // 3. Se não houver níveis inferiores: subir níveis gradualmente
            for (int i = idxCliente + 1; i < niveis.Count; i++)
            {
                var nivelSuperior = elegiveis
                    .Where(p => p.Risco.Equals(niveis[i], StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (nivelSuperior.Any())
                    return nivelSuperior.OrderByDescending(p => p.Rentabilidade).First();
            }

            // 4. Fallback total — maior rentabilidade entre todos
            return elegiveis.OrderByDescending(p => p.Rentabilidade).First();
        }

        public async Task<IEnumerable<ProdutoInvestimento>> ObterProdutosRecomendadosPorPerfilAsync(int perfilId)
        {
            var perfil = await _perfilRiscoRepo.ObterPorIdAsync(perfilId);
            var perfilCliente = perfil.Nome;

            // 1. Buscar todos os tipos disponíveis no repositório
            var tipos = await _produtoRepo.GetTiposDisponiveisAsync();

            var recomendados = new List<ProdutoInvestimento>();

            foreach (var tipo in tipos)
            {
                // 2. Buscar produtos do tipo
                var produtosDoTipo = await _produtoRepo.GetByTipoAsync(tipo);

                if (!produtosDoTipo.Any())
                    continue;

                // 3. Selecionar melhor produto usando o motor
                var melhor = SelecionarMelhorProduto(produtosDoTipo.ToList(), perfilCliente);

                if (melhor != null) recomendados.Add(melhor);
            }

            return recomendados;
        }

    }
}
