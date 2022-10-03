using System;

namespace VendingMachine.Exceptions
{
    public class InvalidManufacturerException : Exception
    {
        public InvalidManufacturerException() :
            base($"Manufacturer is invalid"){}
    }
}
