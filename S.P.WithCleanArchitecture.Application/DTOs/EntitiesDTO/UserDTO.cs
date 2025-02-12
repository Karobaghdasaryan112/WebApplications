using S.P.WithCleanArchitecture.Application.DTOs.ValueObjectDTO;

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
    }
}
