using S.P.WithCleanArchitecture.Application.DTOs.ValueObjectDTO;
using S.P.WithCleanArchitecture.Domain.Entities;

namespace S.P.WithCleanArchiteture.API.ViewModels.User
{
    public class UserProfileViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public AddressDTO Address { get; set; }
        public MoneyDTO Money { get; set; }

    }
}
