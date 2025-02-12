using S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions;

namespace S.P.WithCleanArchitecture.Domain.Exceptions.UserExceptions
{
    public class UserInvalidAgeException : UserBaseException
    {
        public UserInvalidAgeException() : base($"User Age Must be Greather than 3")
        {
        }

        public UserInvalidAgeException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
