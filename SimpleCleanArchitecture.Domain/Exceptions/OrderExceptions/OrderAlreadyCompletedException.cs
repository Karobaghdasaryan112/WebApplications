using S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions;

namespace S.P.WithCleanArchitecture.Domain.Exceptions.OrderExceptions
{
    public class OrderAlreadyCompletedException : OrderBaseException
    {
        public OrderAlreadyCompletedException(int orderId)
               : base($"Order with ID {orderId} has already been completed and cannot be modified.") { }

        public OrderAlreadyCompletedException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
