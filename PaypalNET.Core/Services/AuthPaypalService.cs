using System.Text;
using PaypalNET.Common.Constants;
using PaypalNET.Common.Interfaces;
using PaypalNET.Common.Models.OAuth;
using PaypalNET.Common.Options;
using PaypalNET.Common.Requests.OAuth;
using PaypalNET.Common.Responses.OAuth;
using PaypalNET.Core.Services.Abstractions;
using PaypalNET.Core.Utilities;
using Refit;

namespace PaypalNET.Core.Services
{
    public class AuthPaypalService : BasePaypalService<IOAuthResponse>
    {
        private readonly IOAuthApi _authApi;

        public AuthPaypalService(PaypalApiOptions paypalApiOptions)
        {
            var mode = paypalApiOptions.Mode;
            string baseAddress = (mode == Common.Enums.PaypalApiMode.Sandbox ? PaypalApiLinks.Sandbox : "") + Address;
            _authApi = RestService.For<IOAuthApi>(baseAddress, new RefitSettings()
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(JsonSerializerSettingsServer.GetSettings())
            });
        }

        public override string Address => "v1/oauth2";

        public async Task<IOAuthResponse> GetAccessToken(string clientId, string clientSecret)
        {
            string encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));
            var response = await _authApi.GetAccessToken(encoded, GetAccessTokenRequest.DefaultData);
            return CheckResponseContentAndReturn(response);
        }
    }
}