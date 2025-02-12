using S.P.WithCleanArchitecture.Application.DTOs.ValueObjectDTO;
using S.P.WithCleanArchitecture.Domain.ValueObjects;

namespace S.P.WithCleanArchiteture.API.DTOs.User
{
    public class UserRegistrationViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AddressDTO Address { get; set; }

    }
}
