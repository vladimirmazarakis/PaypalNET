using System.Text;
using PaypalNET.Common.Constants;
using PaypalNET.Common.Errors.OAuth;
using PaypalNET.Common.Interfaces;
using PaypalNET.Common.Models.OAuth;
using PaypalNET.Common.Options;
using PaypalNET.Common.Requests.OAuth;
using PaypalNET.Core.Services.Interfaces;
using Refit;

namespace PaypalNET.Core.Services
{
    public class AuthPaypalService : IPaypalService
    {
        private readonly IOAuthApi _authApi;

        public AuthPaypalService(PaypalApiOptions paypalApiOptions)
        {
            var mode = paypalApiOptions.Mode;
            string baseAddress = (mode == Common.Enums.PaypalApiMode.Sandbox ? PaypalApiLinks.Sandbox : "") + Address;
            _authApi = RestService.For<IOAuthApi>(baseAddress);
        }

        public string Address => "v1/oauth2";

        public async Task<AccessToken> GetAccessToken(string clientId, string clientSecret)
        {
            string encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
            var response = await _authApi.GetAccessToken(encoded, GetAccessTokenRequest.DefaultData);
            if(!response.IsSuccessStatusCode)
            {
                throw response.Error;
            }
            var atResponse = response.Content;
            if(atResponse is null)
            {
                throw new UnableToGetAccessTokenException();
            }
            var accessToken = new AccessToken(atResponse.Scope
                                            , atResponse.AccessToken
                                            , atResponse.TokenType
                                            , atResponse.AppId
                                            , atResponse.ExpiresIn
                                            , atResponse.Nonce);
            return accessToken;
        }
    }
}