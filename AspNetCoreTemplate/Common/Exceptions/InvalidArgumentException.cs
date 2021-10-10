using System;

namespace AspNetCoreTemplate.Common.Exceptions
{
    public abstract class InvalidArgumentException : Exception
    {
        protected InvalidArgumentException() : base("Invalid parameter(s)")
        {
        }

        protected InvalidArgumentException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
