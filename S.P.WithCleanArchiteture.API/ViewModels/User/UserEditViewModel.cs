using S.P.WithCleanArchitecture.Application.DTOs.ValueObjectDTO;

namespace S.P.WithCleanArchiteture.API.ViewModels.User
{
    public class UserEditViewModel
    {
        public string UserName { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public AddressDTO Address { get; set; }
    }
}
