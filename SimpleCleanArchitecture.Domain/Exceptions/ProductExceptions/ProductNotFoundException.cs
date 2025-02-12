using S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions;

namespace S.P.WithCleanArchitecture.Domain.Exceptions.ProductExceptions
{
    public class ProductNotFoundException : ProductBaseException
    {
        public ProductNotFoundException(int ProductId) : base($"Product With ID {ProductId} isn't Exist")
        {
        }

        public ProductNotFoundException(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
