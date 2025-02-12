using AutoMapper;
using S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO;
using S.P.WithCleanArchitecture.Domain.Entities;

namespace S.P.WithCleanArchitecture.Application.Services.Mappings
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryDTO>()
                .ForMember(CDTO => CDTO.Id, opt => opt.MapFrom(C => C.Id))
                .ForMember(CDTO => CDTO.CategoryName, opt => opt.MapFrom(C => C.CategoryName));

            CreateMap<CategoryDTO, Category>()
                .ForMember(C => C.Id,opt => opt.MapFrom(CDTO => CDTO.Id))
                .ForMember(C => C.CategoryName,opt => opt.MapFrom(CDTO => CDTO.CategoryName));

        }
    }
}
