using Kasa.Vchasno.Client.JsonConverters;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace Vchasno.Client.Tests
{
    public class DateTimeOffsetConverterTests
    {
        class DateTimeOffsetTestClass
        {
            public DateTimeOffset Value { get; set; }

            public DateTimeOffset? NullableValue { get; set; }

        }

        private JsonSerializerOptions Create()
        {
            return new JsonSerializerOptions(JsonSerializerDefaults.General)
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                Converters =
                {
                    new DateTimeOffsetJsonConverter()
                }
            };
        }

        [Fact]
        public void Should_write_data_in_given_format()
        {
            var payload = new DateTimeOffsetTestClass()
            {
                NullableValue = null,
                Value = new DateTimeOffset(new DateTime(2021, 12, 2, 12, 3, 4, 095, DateTimeKind.Local))
            };

            var result = JsonSerializer.Serialize(payload, Create());

            Assert.Equal("{\"Value\":\"20211202120304095\"}", result);
        }

        [Fact]
        public void Should_read_data_in_given_format()
        {
            var time = new DateTimeOffset(new DateTime(2021, 12, 2, 12, 3, 4, 095, DateTimeKind.Local));

            const string payload = "{\"Value\":\"20211202120304095\"}";

            var result = JsonSerializer.Deserialize<DateTimeOffsetTestClass>(payload, Create());
            Assert.NotNull(result);
            Assert.Null(result!.NullableValue);
            Assert.Equal(time, result.Value);
        }

        [Fact]
        public void Should_write_nullable_data_in_given_format()
        {
            var payload = new DateTimeOffsetTestClass()
            {
                NullableValue = new DateTimeOffset(new DateTime(2021, 12, 2, 12, 3, 4, 095, DateTimeKind.Local))
            };

            var result = JsonSerializer.Serialize(payload, Create());

            Assert.Equal("{\"NullableValue\":\"20211202120304095\"}", result);
        }
        [Fact]
        public void Should_read_nullable_data_in_given_format()
        {
            var time = new DateTimeOffset(new DateTime(2021, 12, 2, 12, 3, 4, 095, DateTimeKind.Local));

            const string payload = "{\"NullableValue\":\"20211202120304095\"}";

            var result = JsonSerializer.Deserialize<DateTimeOffsetTestClass>(payload, Create());
            Assert.NotNull(result);
            Assert.Equal(time, result!.NullableValue);
        }
    }
}