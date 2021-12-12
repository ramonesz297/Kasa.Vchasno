using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kasa.Vchasno.Client.JsonConverters
{
    public class NullableDateTimeOffsetConverter : JsonConverter<DateTimeOffset?>
    {
        public override DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                var input = reader.GetString();

                return input switch
                {
                    "" => (DateTimeOffset?)null,
                    "0" => (DateTimeOffset?)null,
                    null => (DateTimeOffset?)null,
                    _ => VchasnoDateTimeOffsetReader.Parse(input)
                };
            }
            else
            {
                return null;
            }
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
            {
                writer.WriteStringValue(value.Value.ToLocalTime().ToString(VchasnoDateTimeOffsetReader.Format, CultureInfo.InvariantCulture));
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }
}