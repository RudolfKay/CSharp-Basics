using System;

namespace VendingMachine.Exceptions
{
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException():
            base($"Amount is below zero"){}
    }
}
