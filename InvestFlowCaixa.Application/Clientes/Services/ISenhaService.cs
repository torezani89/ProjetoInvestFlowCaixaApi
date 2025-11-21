using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestFlowCaixa.Application.Clientes.Services
{
    public interface ISenhaService
    {
        void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);
        bool VerificarSenhaHash(string senha, byte[] senhaHash, byte[] senhaSalt);
    }
}
