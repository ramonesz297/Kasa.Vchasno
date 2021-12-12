using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kasa.Vchasno.Client.JsonConverters
{

    public class DateTimeOffsetJsonConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var input = reader.GetString();

            return input switch
            {
                "" => DateTimeOffset.MinValue,
                "0" => DateTimeOffset.MinValue,
                null => DateTimeOffset.MinValue,
                _ => VchasnoDateTimeOffsetReader.Parse(input)
            };
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToLocalTime().ToString(VchasnoDateTimeOffsetReader.Format, CultureInfo.InvariantCulture));
        }
    }
}