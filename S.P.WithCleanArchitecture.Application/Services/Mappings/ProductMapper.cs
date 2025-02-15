

using AutoMapper;
using S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO;
using S.P.WithCleanArchitecture.Domain.Entities;

namespace S.P.WithCleanArchitecture.Application.Services.Mappings
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductDTO, Product>();

            CreateMap<Product,ProductDTO>();
        }
    }
}
