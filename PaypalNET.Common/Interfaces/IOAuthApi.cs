using PaypalNET.Common.Requests.OAuth;
using PaypalNET.Common.Responses.OAuth;
using Refit;

namespace PaypalNET.Common.Interfaces
{
    public interface IOAuthApi
    {
        [Post("/token")]
        Task<IApiResponse<GetAccessTokenResponse>> GetAccessToken([Authorize("Basic")] string base64EncodedCredentials
                                            ,[Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, object> data);
    }
}