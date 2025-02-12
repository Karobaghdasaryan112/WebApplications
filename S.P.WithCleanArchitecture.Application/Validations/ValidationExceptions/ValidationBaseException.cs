namespace S.P.WithCleanArchitecture.Application.Validations.ValidationExceptions
{
    public class ValidationBaseException : Exception
    {
        public ValidationBaseException(string message) : base(message)
        {
        }

        public ValidationBaseException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}
