using System.Formats.Asn1;
using Newtonsoft.Json;
using PaypalNET.Common.Enums;
using PaypalNET.Common.Models;
using PaypalNET.Common.Requests;

namespace PaypalNET.Core.Converters
{
    /// <summary>
    /// <see cref="IUpdateEntityRequestArray"/> conversion handler.
    /// </summary>
    public class UpdateEntityRequestArrayConverter : JsonConverter<IUpdateEntityRequestArray>
    {
        public override IUpdateEntityRequestArray? ReadJson(JsonReader reader, Type objectType, IUpdateEntityRequestArray? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if(reader.TokenType != JsonToken.StartArray)
            {
                throw new JsonSerializationException($"Unexpected token type: {reader.TokenType}. Expected StartArray.");
            }

            var arrayItems = new List<UpdateEntityRequest>();

            while(reader.Read())
            {
                if(reader.TokenType == JsonToken.EndArray)
                {
                    break;
                }
                var item = serializer.Deserialize<UpdateEntityRequest>(reader);
                if(item is null)
                {
                    continue;
                }
                arrayItems.Add(item);
            }

            return new UpdateEntityRequestArray(arrayItems);
        }

        public override void WriteJson(JsonWriter writer, IUpdateEntityRequestArray? value, JsonSerializer serializer)
        {
            writer.WriteStartArray();
            if(value is null || value.Array is null || value.Array.Count <= 0)
            {
                writer.WriteEndArray();
                return;
            }
            foreach(var ueRequest in value.Array)
            {
                serializer.Serialize(writer, ueRequest);
            }
            writer.WriteEndArray();
            return;
        }
    }
}
