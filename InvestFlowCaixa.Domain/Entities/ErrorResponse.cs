using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestFlowCaixa.Domain.Entities
{
    public class ErrorResponse
    {
        public bool Sucesso { get; set; } = false;
        public int StatusCode { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public string? Detalhes { get; set; }
        public string? Caminho { get; set; }
    }
}
