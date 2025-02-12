using S.P.WithCleanArchitecture.Application.DTOs.ValueObjectDTO;
using S.P.WithCleanArchitecture.Domain.Enums;
using S.P.WithCleanArchitecture.Domain.ValueObjects;

namespace S.P.WithCleanArchitecture.Application.DTOs.EntitiesDTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<OrderItemDTO> orderItemDTOs { get; set; } = new List<OrderItemDTO>();
        public AddressDTO Address { get; set; } = null!;
        public OrderStatus Status { get; set; }


    }
}
