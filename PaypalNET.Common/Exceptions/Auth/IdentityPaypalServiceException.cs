using System.Net;

namespace PaypalNET.Common.Exceptions.Auth
{
    public class IdentityPaypalServiceException : PaypalServiceException
    {
        public IdentityPaypalServiceException()
        {
        }

        public IdentityPaypalServiceException(string? message) : base(message)
        {
        }

        public IdentityPaypalServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public IdentityPaypalServiceException(string message, HttpStatusCode statusCode, string errorName = null, Exception innerException = null) : base(message, statusCode, errorName, innerException)
        {
        }
    }
}