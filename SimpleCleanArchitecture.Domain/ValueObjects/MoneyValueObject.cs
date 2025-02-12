
using S.P.WithCleanArchitecture.Domain.Enums;

namespace S.P.WithCleanArchitecture.Domain.ValueObjects
{
    public class MoneyValueObject
    {
        public decimal Amount {  get; set; }
        public Currency currency {  get; set; }
        public MoneyValueObject(decimal amount, Currency currency)
        {
            this.Amount = amount;
            this.currency = currency;
        }
            
    }
}
