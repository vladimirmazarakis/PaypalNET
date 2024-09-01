using System.Net;

namespace PaypalNET.Common.Exceptions
{
    public class TransientPaypalServiceException : PaypalServiceException
    {
        public TransientPaypalServiceException()
        {
        }

        public TransientPaypalServiceException(string? message) : base(message)
        {
        }

        public TransientPaypalServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public TransientPaypalServiceException(string message, HttpStatusCode statusCode, string errorName = null, Exception innerException = null) : base(message, statusCode, errorName, innerException)
        {
        }
    }
}