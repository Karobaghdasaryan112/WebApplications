
using AutoMapper;
using S.P.WithCleanArchitecture.Application.DTOs.ValueObjectDTO;
using S.P.WithCleanArchitecture.Domain.ValueObjects;

namespace S.P.WithCleanArchitecture.Application.Services.Mappings.ObjectValueMaps
{
    public class AddressMapper : Profile
    {
        public AddressMapper() 
        {
            CreateMap<AddressDTO, AddressValueObject>();

            CreateMap<AddressValueObject, AddressDTO>();

        }
    }
}
