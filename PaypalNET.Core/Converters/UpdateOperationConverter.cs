using Newtonsoft.Json;
using PaypalNET.Common.Enums;
using PaypalNET.Common.Models;

namespace PaypalNET.Core.Converters
{
    /// <summary>
    /// Update Operation parse setup.
    /// </summary>
    public class UpdateOperationConverter : JsonConverter<UpdateOperation>
    {
        public override UpdateOperation? ReadJson(JsonReader reader, Type objectType, UpdateOperation? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string? code = reader?.Value?.ToString();
            if(string.IsNullOrEmpty(code))
            {
                return null;
            }
            if(!Enum.TryParse(code, true, out UpdateOperations op))
            {
                return null;
            }
            return new UpdateOperation(op);
        }

        public override void WriteJson(JsonWriter writer, UpdateOperation? value, JsonSerializer serializer)
        {
            if(value is null || string.IsNullOrEmpty(value.Code))
            {
                return;
            }
            writer.WriteValue(value.Code);
        }
    }
}
