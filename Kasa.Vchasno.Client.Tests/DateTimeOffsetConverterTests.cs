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
                    new DateTimeOffsetJsonConverter(),
                    new NullableDateTimeOffsetConverter()
                }
            };
        }

        [Fact]
        public void Should_write_data_in_default_format()
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
        public void Should_read_data_in_default_format()
        {
            var time = new DateTimeOffset(new DateTime(2021, 12, 2, 12, 3, 4, 095, DateTimeKind.Local));

            const string payload = "{\"Value\":\"20211202120304095\"}";

            var result = JsonSerializer.Deserialize<DateTimeOffsetTestClass>(payload, Create());
            Assert.NotNull(result);
            Assert.Null(result!.NullableValue);
            Assert.Equal(time, result.Value);
        }

        [Fact]
        public void Should_read_data_in_additional_format()
        {
            var time = new DateTimeOffset(new DateTime(2021, 12, 11, 13, 22, 1, DateTimeKind.Local));

            const string payload = "{\"Value\":\"11-12-2021 13:22:01\"}";

            var result = JsonSerializer.Deserialize<DateTimeOffsetTestClass>(payload, Create());
            Assert.NotNull(result);
            Assert.Null(result!.NullableValue);
            Assert.Equal(time, result.Value);
        }

        [Fact]
        public void Should_write_nullable_data_in_defaul_format()
        {
            var payload = new DateTimeOffsetTestClass()
            {
                NullableValue = new DateTimeOffset(new DateTime(2021, 12, 2, 12, 3, 4, 095, DateTimeKind.Local))
            };

            var result = JsonSerializer.Serialize(payload, Create());

            Assert.Equal("{\"NullableValue\":\"20211202120304095\"}", result);
        }
        [Fact]
        public void Should_read_nullable_data_in_default_format()
        {
            var time = new DateTimeOffset(new DateTime(2021, 12, 2, 12, 3, 4, 095, DateTimeKind.Local));

            const string payload = "{\"NullableValue\":\"20211202120304095\"}";

            var result = JsonSerializer.Deserialize<DateTimeOffsetTestClass>(payload, Create());
            Assert.NotNull(result);
            Assert.Equal(time, result!.NullableValue);
        }

        [Fact]
        public void Should_read_nullable_data_in_additional_format()
        {
            var time = new DateTimeOffset(new DateTime(2021, 12, 11, 13, 22, 1, DateTimeKind.Local));

            const string payload = "{\"NullableValue\":\"11-12-2021 13:22:01\"}";

            var result = JsonSerializer.Deserialize<DateTimeOffsetTestClass>(payload, Create());
            Assert.NotNull(result);
            Assert.Equal(time, result!.NullableValue);
        }


        [Theory]
        [InlineData("")]
        [InlineData("0")]
        public void Should_read_vchasno_constant_as_null(string vchasnoConstant)
        {
            string payload = $"{{\"NullableValue\":\"{vchasnoConstant}\"}}";

            var result = JsonSerializer.Deserialize<DateTimeOffsetTestClass>(payload, Create());
            Assert.NotNull(result);
            Assert.Null(result!.NullableValue);
        }


        [Theory]
        [InlineData("")]
        [InlineData("0")]
        public void Should_read_vchasno_constant_as_min_date(string vchasnoConstant)
        {
            string payload = $"{{\"Value\":\"{vchasnoConstant}\"}}";

            var result = JsonSerializer.Deserialize<DateTimeOffsetTestClass>(payload, Create());
            Assert.NotNull(result);
            Assert.Equal(DateTimeOffset.MinValue, result!.Value);
        }
    }
}