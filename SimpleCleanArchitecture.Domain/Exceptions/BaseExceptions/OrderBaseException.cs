

namespace S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions
{
    public class OrderBaseException : Exception
    {
        public OrderBaseException(string message, Exception ex) : base(message, ex) { }
        public OrderBaseException(string message) : base(message) { }
    }
}
