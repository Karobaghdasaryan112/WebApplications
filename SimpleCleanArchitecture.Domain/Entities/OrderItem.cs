using S.P.WithCleanArchitecture.Domain.ValueObjects;

namespace S.P.WithCleanArchitecture.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int ProductCount;

        public MoneyValueObject ItemPrice => Product.ProductPrice != null ? 
            new MoneyValueObject(Product.ProductPrice.Amount,Product.ProductPrice.currency) 
            : new MoneyValueObject(0,Enums.Currency.USD);

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null!;

    }
}
