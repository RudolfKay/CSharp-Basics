using System;

namespace VendingMachine.Exceptions
{
    public class InvalidVendingSlotCountException : Exception
    {
        public InvalidVendingSlotCountException() :
            base($"Vending slot count is invalid"){}
    }
}
