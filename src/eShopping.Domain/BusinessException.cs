using System;

namespace eShopping.Domain
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }
        public BusinessException(string message) : base(message)
        {
        }
    }
}