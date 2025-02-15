
using S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions;

namespace S.P.WithCleanArchitecture.Domain.Exceptions.UserExceptions
{
    public class UserUpdateException : UserBaseException
    {
        public UserUpdateException(string message) : base(message)
        {
        }

        public UserUpdateException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
