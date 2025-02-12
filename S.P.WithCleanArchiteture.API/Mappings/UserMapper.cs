using AutoMapper;
using S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO;
using S.P.WithCleanArchitecture.Infrastructure.Utils.PasswordHelper;
using S.P.WithCleanArchiteture.API.DTOs.User;

namespace S.P.WithCleanArchiteture.API.Mappings
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {

            CreateMap<UserRegistrationViewModel, UserDTO>()
                .ForMember(UDTO => UDTO.PasswordHash, opt => opt.MapFrom(UserViewModel => PasswordHasher.HashPassword(UserViewModel.Password)));

            CreateMap<UserLoginViewModel, UserDTO>()
                .ForMember(UDTO => UDTO.PasswordHash, opt => opt.MapFrom(UserViewModel => PasswordHasher.HashPassword(UserViewModel.Password)));

        }
    }
}
