using System;

namespace VendingMachine.Exceptions
{
    public class InvalidMoneyException : Exception
    {
        public InvalidMoneyException() :
            base($"Price is invalid"){}
    }
}
