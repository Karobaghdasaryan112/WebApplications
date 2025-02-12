

namespace S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions
{
    public class UserBaseException : Exception
    {
        public UserBaseException(string message, Exception ex) : base(message, ex) { }
        public UserBaseException(string message) : base(message) { }
    }
}
