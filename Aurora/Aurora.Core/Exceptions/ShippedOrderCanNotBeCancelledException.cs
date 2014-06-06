using System;

namespace Aurora.Core.Exceptions
{
    public class ShippedOrderCanNotBeCancelledException : Exception
    {
        public ShippedOrderCanNotBeCancelledException()
        {
        }

        public ShippedOrderCanNotBeCancelledException(string message) : base(message)
        {
        }

        public ShippedOrderCanNotBeCancelledException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}