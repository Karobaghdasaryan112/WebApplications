using AutoMapper;
using S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO;
using S.P.WithCleanArchitecture.Infrastructure.Utils.PasswordHelper;
using S.P.WithCleanArchiteture.API.DTOs.User;
using S.P.WithCleanArchiteture.API.ViewModels.User;

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

            CreateMap<UserDTO, UserProfileViewModel>();

            CreateMap<UserEditViewModel, UserDTO>()
                .ForMember(UDTO => UDTO.PasswordHash, opt => opt.MapFrom(EditViewModel => PasswordHasher.HashPassword(EditViewModel.NewPassword)));

            CreateMap<UserDTO, UserEditViewModel>()
                .ForMember(EditViewModel => EditViewModel. NewPassword, opt => opt.MapFrom(UDTO => UDTO.PasswordHash));
        }
    }
}
