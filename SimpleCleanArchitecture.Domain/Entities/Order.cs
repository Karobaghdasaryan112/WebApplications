using S.P.WithCleanArchitecture.Domain.Enums;
using S.P.WithCleanArchitecture.Domain.ValueObjects;

namespace S.P.WithCleanArchitecture.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public MoneyValueObject TotalPrice => Items.Any()
            ? new MoneyValueObject(Items.Sum(OI => OI.ItemPrice.Amount), Items.First().ItemPrice.currency) : new MoneyValueObject(0, Currency.USD);
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public AddressValueObject Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }   
}
    