using S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions;


namespace S.P.WithCleanArchitecture.Domain.Exceptions.OrderExceptions
{
    public class OrderItemNotFoundException : OrderBaseException
    {
        public OrderItemNotFoundException(int orderId, int productId)
            : base($"Product with ID {productId} was not found in order ID {orderId}.") { }

        public OrderItemNotFoundException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
