using S.P.WithCleanArchitecture.Application.DTOs.ValueObjectDTO;
using S.P.WithCleanArchitecture.Application.Interfaces;

namespace S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO
{
    public class UserDTO 
    {
        public UserDTO() { }
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int Age { get; set; }
        public MoneyDTO Money { get; set; }
        public AddressDTO Address { get; set; }



        //public override string ToString()
        //{
        //    return $"User:" +
        //           $" {nameof(UserName)}:{UserName}, " +
        //           $"{nameof(FirstName)}:{FirstName}, " +
        //           $"{nameof(LastName)}:{LastName}, " +
        //           $"{nameof(Email)}:{Email}, " +
        //           $"{nameof(Money)}: " +
        //           $" [{nameof(Money.Amount)}:{Money?.Amount ?? 0}, " +
        //           $"{nameof(Money.currency)}:{Money?.currency}], " +
        //           $"{nameof(Address)}: " +
        //           $" [{nameof(Address.Street)}:{Address?.Street ?? "N/A"}, " +
        //           $"{nameof(Address.PostalCode)}:{Address?.PostalCode ?? "N/A"}, " +
        //           $"{nameof(Address.City)}:{Address?.City ?? "N/A"}, " +
        //           $"{nameof(Address.Country)}:{Address?.Country ?? "N/A"}]";
        //}

    }
}
