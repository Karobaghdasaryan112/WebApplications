using AutoMapper;
using S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO;
using S.P.WithCleanArchitecture.Domain.Entities;

namespace S.P.WithCleanArchitecture.Application.Services.Mappings.UserMaps
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserDTO, User>();

            CreateMap<User, UserDTO>();


        }
    }
}
