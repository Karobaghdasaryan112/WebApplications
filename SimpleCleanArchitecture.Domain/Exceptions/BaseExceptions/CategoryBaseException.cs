

namespace S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions
{
    public class CategoryBaseException : Exception
    {
        public CategoryBaseException(string message, Exception ex) : base(message, ex) { }
        public CategoryBaseException(string message) : base(message) { }
    }
}
