using System;

namespace Hierarchy.Exceptions
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException():
            base($"Name is invalid"){}
    }
}
