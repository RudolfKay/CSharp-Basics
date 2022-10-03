using System;

namespace VendingMachine.Exceptions
{
    public class InvalidProductCountException : Exception
    {
        public InvalidProductCountException() :
            base($"Cannot add product with invalid count"){}
    }
}
