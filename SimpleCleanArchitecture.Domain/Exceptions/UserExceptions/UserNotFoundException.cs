using S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions;

namespace S.P.WithCleanArchitecture.Domain.Exceptions.UserExceptions
{
    public class UserNotFoundException : UserBaseException
    {
        public UserNotFoundException(string[] userNameAndPassword)
            : base($"User With UserName {userNameAndPassword[0]} And with Password {userNameAndPassword[1]} doesnt Exist")
        {
        }

        public UserNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public UserNotFoundException(string message) : base(message)
        {

        }
    }
}
