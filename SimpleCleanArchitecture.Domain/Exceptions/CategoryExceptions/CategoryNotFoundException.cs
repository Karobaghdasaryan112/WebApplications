using S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions;

namespace S.P.WithCleanArchitecture.Domain.Exceptions.CategoryExceptions
{
    public class CategoryNotFoundException : CategoryBaseException
    {
        public CategoryNotFoundException(string message) : base(message)
        {
        }

        public CategoryNotFoundException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
