using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kasa.Vchasno.Client.JsonConverters
{
    public class DateTimeOffsetJsonConverter : JsonConverter<DateTimeOffset>
    {
        private const string format = "yyyyMMddHHmmssFFF";
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTimeOffset.ParseExact(reader.GetString(), format, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToLocalTime().ToString(format, CultureInfo.InvariantCulture));
        }
    }
}