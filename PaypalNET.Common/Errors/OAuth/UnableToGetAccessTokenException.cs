using System.Runtime.Serialization;

namespace PaypalNET.Common.Errors.OAuth
{
    public class UnableToGetAccessTokenException : Exception
    {
        public UnableToGetAccessTokenException() : base("Access token was null.")
        {
        }
    }
}