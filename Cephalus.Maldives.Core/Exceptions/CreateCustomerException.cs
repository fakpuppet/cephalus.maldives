using System;

namespace Cephalus.Maldives.Core.Exceptions
{
    public class CreateCustomerException : Exception
    {
        public CreateCustomerException(Exception ex) 
            : this("Error occurred when creating a Customer", ex)
        { }

        public CreateCustomerException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}