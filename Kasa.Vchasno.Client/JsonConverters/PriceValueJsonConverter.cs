using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Kasa.Vchasno.Client.ValueTypes;

namespace Kasa.Vchasno.Client.JsonConverters
{
    public class PriceValueJsonConverter : JsonConverter<PriceValue>
    {
        public override PriceValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetDecimal();
        }

        public override void Write(Utf8JsonWriter writer, PriceValue value, JsonSerializerOptions options)
        {
            writer.WriteRawValue(((decimal)value).ToString("F2"));
        }
    }
}