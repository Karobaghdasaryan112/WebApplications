using AutoMapper;
using S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO;
using S.P.WithCleanArchiteture.API.DTOs.Category;

namespace S.P.WithCleanArchiteture.API.Mappings
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {

            CreateMap<CategoryViewModel, CategoryDTO>();

            CreateMap<CategoryDTO, CategoryViewModel>();
        }
    }
}
