using System;

namespace Hierarchy.Exceptions
{
    public class InvalidWeightException : Exception
    {
        public InvalidWeightException():
            base($"Weight is invalid"){}
    }
}
