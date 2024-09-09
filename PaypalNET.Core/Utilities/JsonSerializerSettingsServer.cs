using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PaypalNET.Core.ContractResolvers;
using PaypalNET.Core.Converters;

namespace PaypalNET.Core.Utilities
{
    /// <summary>
    /// Serves default Json Serializer Settings.
    /// </summary>
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
                    Formatting = Formatting.Indented,
                    Converters = 
                    [
                        new UpdateOperationConverter(),
                        new UpdateEntityListContainerConverter()
                    ]
            };
            return settings;
        }
    }
}
