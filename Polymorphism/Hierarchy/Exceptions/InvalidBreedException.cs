using System;

namespace Hierarchy.Exceptions
{
    public class InvalidBreedException : Exception
    {
        public InvalidBreedException():
            base($"Cat breed is invalid"){}
    }
}
