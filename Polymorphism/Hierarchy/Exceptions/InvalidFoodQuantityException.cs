using System;

namespace Hierarchy.Exceptions
{
    public class InvalidFoodQuantityException : Exception
    {
        public InvalidFoodQuantityException():
            base($"Food quantity is invalid"){}
    }
}
