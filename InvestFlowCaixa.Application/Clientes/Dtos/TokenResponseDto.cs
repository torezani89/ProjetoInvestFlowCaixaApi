using System.Text.Json.Serialization;

namespace InvestFlowCaixa.Application.Clientes.Dtos
{
    public class TokenResponseDto
    {
        public string Token { get; set; }

        [JsonIgnore]
        public DateTime Expiration { get; set; }

        public DateTime ExpirationBrazil
            => TimeZoneInfo.ConvertTimeFromUtc(
                   Expiration,
                   TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time")
               );
    }

}
