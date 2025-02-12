using S.P.WithCleanArchitecture.Application.DTOs.ValueObjectDTO;

namespace S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductCount;
        public int OrderId { get; set; }
        public MoneyDTO ItemPrice { get; set; }

    }
}
