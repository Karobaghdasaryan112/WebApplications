using S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions;

namespace S.P.WithCleanArchitecture.Domain.Exceptions.ProductExceptions
{
    public class ProductCategoryNotFoundException : ProductBaseException
    {

        public ProductCategoryNotFoundException(int ProductId) : base($"The Product Category By With Id {ProductId} Isn't Found")
        {
        }

        public ProductCategoryNotFoundException(string message, Exception ex) : base(message, ex)
        {
        }

    }
}
