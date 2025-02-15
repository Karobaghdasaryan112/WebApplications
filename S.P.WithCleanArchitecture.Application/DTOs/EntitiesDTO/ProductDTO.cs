using S.P.WithCleanArchitecture.Application.DTOs.ValueObjectDTO;

namespace S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public MoneyDTO Money { get; set; }
    }
}
