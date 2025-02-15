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
                .ForMember(CDTO => CDTO.CategoryName, opt => opt.MapFrom(C => C.CategoryName))
                .ForMember(CDTO => CDTO.ProductsDTO, opt => opt.MapFrom(C => C.Products));

            CreateMap<CategoryDTO, Category>()
                .ForMember(C => C.CategoryName,opt => opt.MapFrom(CDTO => CDTO.CategoryName))
                .ForMember(C => C.Products,opt => opt.MapFrom(CDTO => CDTO.ProductsDTO));
                
        }
    }
}
