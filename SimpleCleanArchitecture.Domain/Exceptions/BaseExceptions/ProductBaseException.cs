using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.P.WithCleanArchitecture.Domain.Exceptions.BaseExceptions
{
    public class ProductBaseException : Exception
    {
        public ProductBaseException(string message, Exception ex) : base(message, ex) { }
        public ProductBaseException(string message) : base(message) { }
    }
}
