using System;

namespace RepositoryPattern.Common.Exceptions
{
    public class BusinessException : Exception
    {
        public string ErrorCode { get; set; }

        public BusinessException() : base("Business exception")
        {
        }

        public BusinessException(string errorMessage, string errorCode = "") : base(errorMessage)
        {
            ErrorCode = errorCode;
        }
    }
}
