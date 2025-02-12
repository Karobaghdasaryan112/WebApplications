using S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions;

namespace S.P.WithCleanArchitecture.Domain.Exceptions.ProductExceptions
{
    public class ProductCountInvalidException : ProductBaseException
    {
        public ProductCountInvalidException(int ProductCount) :
            base(
                ProductCount > 0 ?
            $"Product With {ProductCount} this Count isn't Exist " :
            "ProductCount cannot be less  than 0")
        {
        }

        public ProductCountInvalidException(string message, Exception ex) : base(message, ex) {}

    }
}
