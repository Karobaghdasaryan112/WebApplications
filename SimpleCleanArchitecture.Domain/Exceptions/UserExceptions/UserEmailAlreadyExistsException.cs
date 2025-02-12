using S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions;

namespace S.P.WithCleanArchitecture.Domain.Exceptions.UserExceptions
{
    public class UserEmailAlreadyExistsException : UserBaseException
    {
        public UserEmailAlreadyExistsException(string Email) : base($"User With {Email} this Email is Already Exist")
        {
        }

        public UserEmailAlreadyExistsException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
