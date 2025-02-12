namespace S.P.WithCleanArchitecture.Application.Validations.ValidationExceptions
{
    public class InvalidDataFormatException : ValidationBaseException
    {

        public InvalidDataFormatException(string[] parameters)
            : base($"Invalid DataFormat: {string.Join(", ", parameters.Select(p => p?.ToString() ?? "Unknown") + " isn't Valid")}")
        {

        }

        public InvalidDataFormatException(string message, Exception exception) : base(message, exception)
        {
        }

        //Custom Message for Exception
        public InvalidDataFormatException(string message) : base(message)
        {

        }

    }
}
