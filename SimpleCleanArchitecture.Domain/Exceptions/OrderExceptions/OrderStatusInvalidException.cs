using S.P.WithCleanArchitecture.Domain.Enums;
using S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions;

namespace S.P.WithCleanArchitecture.Domain.Exceptions.OrderExceptions
{
    public class OrderStatusInvalidException : OrderBaseException
    {
        public OrderStatusInvalidException(OrderStatus status)
            : base($"Order status '{status}' is invalid for this operation.") { }

        public OrderStatusInvalidException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
