using S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions;

namespace S.P.WithCleanArchitecture.Domain.Exceptions.OrderExceptions
{
    public class OrderNotFoundException : OrderBaseException
    {
        public OrderNotFoundException(int orderId)
               : base($"Order with ID {orderId} was not found.") { }

        public OrderNotFoundException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
