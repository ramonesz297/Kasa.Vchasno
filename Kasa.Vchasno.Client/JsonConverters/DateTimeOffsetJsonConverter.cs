using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kasa.Vchasno.Client.JsonConverters
{
    public class DateTimeOffsetJsonConverter : JsonConverter<DateTimeOffset>
    {
        private const string _format = "yyyyMMddHHmmssFFF";
        private const string _additionalFormat = "dd-MM-yyyy HH:mm:ss";
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var input = reader.GetString();

            if (DateTimeOffset.TryParseExact(input, _format, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var result))
            {
                return result;
            }
            else if (DateTimeOffset.TryParseExact(input, _additionalFormat, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out result))
            {
                return result;
            }
            else
            {
                return DateTimeOffset.MinValue;
            }
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToLocalTime().ToString(_format, CultureInfo.InvariantCulture));
        }
    }
}