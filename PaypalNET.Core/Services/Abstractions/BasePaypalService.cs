using PaypalNET.Core.Utilities;
using Refit;

namespace PaypalNET.Core.Services.Abstractions
{
    /// <summary>
    /// Base Paypal Service, handles response checking and returning.
    /// </summary>
    /// <typeparam name="T">Type of response.</typeparam>
    public abstract class BasePaypalService<T>
    {
        /// <summary>
        /// Endpoint address. (Base endpoint is assigned automatically)
        /// </summary>
        public abstract string Address { get; }

        public T CheckResponseContentAndReturn(IApiResponse<T> apiResponse)
        {
            if(apiResponse.IsSuccessStatusCode && apiResponse.Content != null)
            {
                return apiResponse.Content;
            }
            else
            {
                throw PaypalErrorHandler.HandleApiException(apiResponse.Error);
            }
        }

        public void CheckResponseContent(IApiResponse apiResponse)
        {
            if(apiResponse.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw PaypalErrorHandler.HandleApiException(apiResponse.Error);
            }
        }
    }
}