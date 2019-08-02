using System;

namespace Exceptions
{
    public class WrongExpressionException : ApplicationException
    {
        public WrongExpressionException(string message) : base(message)
        {

        }
    }
}