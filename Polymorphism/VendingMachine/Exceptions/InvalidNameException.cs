using System;

namespace VendingMachine.Exceptions
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException() :
            base($"Product name is invalid"){}
    }
}
