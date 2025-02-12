using S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions;

namespace S.P.WithCleanArchitecture.Domain.Exceptions.UserExceptions
{
    public class UserNotFoundException : UserBaseException
    {
        public UserNotFoundException(string userName)
            : base(string.IsNullOrWhiteSpace(userName)
                  ? "User does not exist."
                  : $"User with username '{userName}' does not exist.")
        {
        }

        public UserNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
