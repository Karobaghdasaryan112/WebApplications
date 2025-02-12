
namespace S.P.WithCleanArchitecture.Application.Validations.ValidationExceptions
{
    public class NullViewModelException : ValidationBaseException
    {
        public NullViewModelException(string nameofViewModel) : base($"{nameofViewModel} cannot be null.")
        {
        }

        public NullViewModelException(string message, Exception exception) : base(message, exception)
        {
        }
    

    }
}
