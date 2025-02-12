using S.P.WithCleanArchitecture.Domain.ValueObjects;

namespace S.P.WithCleanArchitecture.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public MoneyValueObject ProductPrice { get; set; } = null!;

        public ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    }
}   
