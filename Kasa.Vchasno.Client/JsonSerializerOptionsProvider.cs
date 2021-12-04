using Kasa.Vchasno.Client.JsonConverters;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kasa.Vchasno.Client
{
    public class JsonSerializerOptionsProvider : IJsonSerializerOptionsProvider
    {
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.General)
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters =
            {
                new DateTimeOffsetJsonConverter(),
                new PriceValueJsonConverter(),
                new CountValueJsonConverter()
            }
        };

        public JsonSerializerOptions Options => _jsonOptions;
    }
}