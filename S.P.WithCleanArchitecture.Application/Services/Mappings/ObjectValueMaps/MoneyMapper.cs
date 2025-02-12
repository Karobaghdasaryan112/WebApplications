using AutoMapper;
using S.P.WithCleanArchitecture.Application.DTOs.ValueObjectDTO;
using S.P.WithCleanArchitecture.Domain.ValueObjects;

namespace S.P.WithCleanArchitecture.Application.Services.Mappings.ObjectValueMaps
{
    public class MoneyMapper : Profile
    {
        public MoneyMapper() 
        {
            CreateMap<MoneyDTO, MoneyValueObject>();
            CreateMap<AddressDTO, AddressValueObject>();

            CreateMap<MoneyValueObject, MoneyDTO>();
            CreateMap<AddressValueObject, AddressDTO>();
        }
    }
}
