using System;

namespace Hierarchy.Exceptions
{
    public class InvalidTypeException : Exception
    {
        public InvalidTypeException():
            base($"Type is invalid"){}
    }
}
