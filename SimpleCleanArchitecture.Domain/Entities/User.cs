using S.P.WithCleanArchitecture.Domain.ValueObjects;

namespace S.P.WithCleanArchitecture.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int Age { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedAt { get; set; }
        public MoneyValueObject Money { get; set; } = null!;

        public AddressValueObject Address { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
