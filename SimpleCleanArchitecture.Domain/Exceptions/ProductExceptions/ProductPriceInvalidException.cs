using S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions;

namespace S.P.WithCleanArchitecture.Domain.Exceptions.ProductExceptions
{
    public class ProductPriceInvalidException : ProductBaseException
    {


        public ProductPriceInvalidException(decimal price, int productId)
            : base($"Invalid price '{price}' for product with ID {productId}. Price must be greater than zero.")
        {
        }

        public ProductPriceInvalidException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
