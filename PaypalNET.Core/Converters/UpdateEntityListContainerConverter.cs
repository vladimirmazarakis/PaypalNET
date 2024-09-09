using System.Formats.Asn1;
using Newtonsoft.Json;
using PaypalNET.Common.Enums;
using PaypalNET.Common.Models;
using PaypalNET.Common.Requests;

namespace PaypalNET.Core.Converters
{
    /// <summary>
    /// <see cref="IUpdateEntityListContainer"/> conversion handler.
    /// </summary>
    public class UpdateEntityListContainerConverter : JsonConverter<IUpdateEntityListContainer>
    {
        public override IUpdateEntityListContainer? ReadJson(JsonReader reader, Type objectType, IUpdateEntityListContainer? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if(reader.TokenType != JsonToken.StartArray)
            {
                throw new JsonSerializationException($"Unexpected token type: {reader.TokenType}. Expected StartArray.");
            }

            var arrayItems = new List<UpdateEntity>();

            while(reader.Read())
            {
                if(reader.TokenType == JsonToken.EndArray)
                {
                    break;
                }
                var item = serializer.Deserialize<UpdateEntity>(reader);
                if(item is null)
                {
                    continue;
                }
                arrayItems.Add(item);
            }

            return new UpdateEntityListContainer(arrayItems);
        }

        public override void WriteJson(JsonWriter writer, IUpdateEntityListContainer? value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            if(value is null || value.List is null || value.List.Count <= 0)
            {
                writer.WriteEndArray();
                return;
            }
            foreach(var ueRequest in value.List)
            {
                serializer.Serialize(writer, ueRequest);
            }
            writer.WriteEndArray();
            return;
        }
    }
}
