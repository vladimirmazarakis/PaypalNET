using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PaypalNET.Common.Constants;
using PaypalNET.Common.Enums;
using PaypalNET.Common.Models.OAuth;
using PaypalNET.Common.Options;
using PaypalNET.Core.ContractResolvers;
using PaypalNET.Core.Services.Interfaces;
using Refit;

namespace PaypalNET.Core.Services
{
    public abstract class AuthorizedPaypalService<T> : IPaypalService
    {
        protected T Service { get; set; }
        public abstract string Address { get; }
        protected AccessToken AccessToken { get; set; }

        public AuthorizedPaypalService(PaypalApiOptions paypalApiOptions, AccessToken accessToken)
        {
            AccessToken = accessToken;
            string baseAddress = paypalApiOptions.Mode == PaypalApiMode.Sandbox ? PaypalApiLinks.Sandbox : "";
            
            CustomRequestContractResolver contractResolver = new CustomRequestContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };
            Service = RestService.For<T>(baseAddress + Address, new RefitSettings()
            {
                AuthorizationHeaderValueGetter = (_, _) => GetAccessToken(),
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented
                })
                // ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
                // {
                // PropertyNameCaseInsensitive = true,
                // PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
                // Converters =
                // {
                //     (JsonConverter)new ObjectToInferredTypesConverter(),
                //     (JsonConverter)new JsonStringEnumConverter(JsonNamingPolicy.SnakeCaseLower)
                // }
                // })
            });
        }

        private Task<string> GetAccessToken()
        {
            return Task.FromResult(AccessToken.Value);
        }
    }
}
