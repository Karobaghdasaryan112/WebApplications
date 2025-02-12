using S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions;

namespace S.P.WithCleanArchitecture.Domain.Exceptions.UserExceptions
{
    public class UserPasswordInvalidException : UserBaseException
    {
        public UserPasswordInvalidException()
            : base("The provided password is invalid.")
        {
        }

        public UserPasswordInvalidException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public UserPasswordInvalidException(string attemptedPassword)
            : base($"The password '{attemptedPassword}' is invalid or does not meet security requirements.")
        {
        }
    }
}
