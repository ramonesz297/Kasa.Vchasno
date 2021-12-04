using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Kasa.Vchasno.Client.ValueTypes;

namespace Kasa.Vchasno.Client.JsonConverters
{
    public class CountValueJsonConverter : JsonConverter<CountValue>
    {
        public override CountValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetDecimal();
        }

        public override void Write(Utf8JsonWriter writer, CountValue value, JsonSerializerOptions options)
        {
            writer.WriteRawValue(((decimal)value).ToString("F3"));
        }
    }
}