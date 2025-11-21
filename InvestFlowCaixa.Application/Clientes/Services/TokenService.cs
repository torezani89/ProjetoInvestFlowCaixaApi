using InvestFlowCaixa.Application.Clientes.Dtos;
using InvestFlowCaixa.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace InvestFlowCaixa.Application.Clientes.Services
{
    public class TokenService : ITokenService
    {

        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public TokenResponseDto CriarToken(Cliente cliente)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Nome", cliente.Nome),
            };

            var jwtSettings = _config.GetSection("Jwt");
            var Key = jwtSettings["Key"];

            if (string.IsNullOrEmpty(Key))
            {
                throw new InvalidOperationException("A chave JWT não foi configurada em appsettings.json");
            }

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Key));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims, // informações do usuário que vão dentro do token.
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["ExpirationMinutes"])),
                //expires: DateTime.Now.AddDays(1), // data de expiração → 1 dia a partir de agora.
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                signingCredentials: credentials // assinatura com a chave secreta (Chave Simétrica) e o algoritmo escolhido (HmacSha512).
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenResponseDto { Token = jwt, Expiration = token.ValidTo };
        }
    }
}
