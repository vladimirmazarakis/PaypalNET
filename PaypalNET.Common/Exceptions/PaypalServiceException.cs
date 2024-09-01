using System.Net;
using System.Runtime.Serialization;

namespace PaypalNET.Common.Exceptions
{
    public class PaypalServiceException : Exception
    {
        public HttpStatusCode StatusCode { get; init; }
        public string ErrorName { get; init; }
        public string ErrorMessage { get; init; }

        public PaypalServiceException
        (string message, HttpStatusCode statusCode, string errorName = null, Exception innerException = null) 
        : base(message, innerException)
        {
            StatusCode = statusCode;
            ErrorName = errorName;
            ErrorMessage = message;
        }

        public PaypalServiceException()
        {
        }

        public PaypalServiceException(string? message) : base(message)
        {
        }

        public PaypalServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}