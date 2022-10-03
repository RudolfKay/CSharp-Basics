using System;

namespace VendingMachine.Exceptions
{
    public class MachineIsEmptyException : Exception
    {
        public MachineIsEmptyException() :
            base($"Vending machine is empty"){}
    }
}
