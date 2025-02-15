using S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO;

namespace S.P.WithCleanArchiteture.API.DTOs.Category
{
    public class CategoryViewModel
    {
        public string CategoryName { get; set; }
        public ICollection<ProductDTO> ProductsDTO { get; set; } = new List<ProductDTO>();

    }
}
