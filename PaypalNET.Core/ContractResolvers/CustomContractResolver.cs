using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PaypalNET.Core.ContractResolvers
{
    internal class CustomContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            
            // If the property is a string, and you want to exclude empty strings
            if (property.PropertyType == typeof(string))
            {
                property.ShouldSerialize = instance =>
                {
                    var value = property?.ValueProvider?.GetValue(instance) as string;
                    return !string.IsNullOrEmpty(value); // Exclude empty strings
                };
            }
            
            return property;
        }
    }
}