using AutoMapper;
using S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO;
using S.P.WithCleanArchitecture.Domain.Entities;

namespace S.P.WithCleanArchitecture.Application.Services.Mappings.UserMaps
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserDTO, User>()
                .ForMember(User => User.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(User => User.Money, opt => opt.MapFrom(src => src.Money));
        }
    }
}
