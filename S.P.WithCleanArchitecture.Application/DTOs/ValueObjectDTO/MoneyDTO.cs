using S.P.WithCleanArchitecture.Domain.Enums;

namespace S.P.WithCleanArchitecture.Application.DTOs.ValueObjectDTO
{
    public class MoneyDTO
    {
        public decimal Amount { get; set; }
        public Currency currency { get; set; }

        public MoneyDTO(decimal amount, Currency currency)
        {
            Amount = amount;
            this.currency = currency;
        }
    }
}
