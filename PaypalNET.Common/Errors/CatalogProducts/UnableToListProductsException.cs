using System.Runtime.Serialization;

namespace PaypalNET.Common.Errors.CatalogProducts
{
    public class UnableToListProductsException : Exception
    {
        public UnableToListProductsException() : base("Unable to get list of products.")
        {
        }
    }
}