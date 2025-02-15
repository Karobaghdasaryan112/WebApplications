using S.P.WithCleanArchitecture.Domain.Entities;

namespace S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO
{
    public class CategoryDTO
    {
        public string CategoryName { get; set; }
        public ICollection<ProductDTO> ProductsDTO { get; set; } = new List<ProductDTO>();

    }
}
