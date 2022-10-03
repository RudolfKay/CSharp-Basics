using System;

namespace Hierarchy.Exceptions
{
    public class InvalidRegionException : Exception
    {
        public InvalidRegionException():
            base($"Region is invalid"){}
    }
}
