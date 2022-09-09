using System;

namespace VendingMachine.Exceptions
{
    public class InvalidSelectionException : Exception
    {
        public InvalidSelectionException() :
            base($"Selected product number is invalid"){}
    }
}
