using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PaypalNET.Core.ContractResolvers;

namespace PaypalNET.Core.Utilities
{
    public static class JsonSerializerSettingsServer
    {
        public static JsonSerializerSettings GetSettings()
        {
            CustomContractResolver contractResolver = new CustomContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };
            var settings = new JsonSerializerSettings()
            {
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore,
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented
            };
            return settings;
        }
    }
}
