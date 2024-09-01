using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PaypalNET.Common.Constants;
using PaypalNET.Common.Enums;
using PaypalNET.Common.Models.OAuth;
using PaypalNET.Common.Options;
using PaypalNET.Core.ContractResolvers;
using PaypalNET.Core.Services.Abstractions;
using PaypalNET.Core.Utilities;
using Refit;

namespace PaypalNET.Core.Services
{
    public abstract class AuthorizedPaypalService<T, G> : BasePaypalService<G>
    {
        protected T Service { get; set; }
        public override abstract string Address { get; }
        protected AccessToken AccessToken { get; set; }

        public AuthorizedPaypalService(PaypalApiOptions paypalApiOptions, AccessToken accessToken)
        {
            AccessToken = accessToken;
            string baseAddress = paypalApiOptions.Mode == PaypalApiMode.Sandbox ? PaypalApiLinks.Sandbox : "";
            
            Service = RestService.For<T>(baseAddress + Address, new RefitSettings()
            {
                AuthorizationHeaderValueGetter = (_, _) => GetAccessToken(),
                ContentSerializer = new NewtonsoftJsonContentSerializer(JsonSerializerSettingsServer.GetSettings())
            });
        }

        private Task<string> GetAccessToken()
        {
            return Task.FromResult(AccessToken.Value);
        }
    }
}
