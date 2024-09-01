using PaypalNET.Core.Utilities;
using Refit;

namespace PaypalNET.Core.Services.Abstractions
{
    public abstract class BasePaypalService<T>
    {
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
    }
}