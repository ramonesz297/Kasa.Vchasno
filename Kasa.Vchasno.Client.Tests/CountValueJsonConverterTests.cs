using Kasa.Vchasno.Client.JsonConverters;
using Kasa.Vchasno.Client.ValueTypes;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace Vchasno.Client.Tests
{
    public class CountValueJsonConverterTests
    {
        class CountValueTestClass
        {
            public CountValue Value { get; set; }
        }

        private JsonSerializerOptions Create()
        {
            return new JsonSerializerOptions(JsonSerializerDefaults.General)
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                Converters =
                {
                    new CountValueJsonConverter()
                }
            };
        }

        public static class PriceValuesTestData
        {
            public static IEnumerable<object[]> Get()
            {
                yield return new object[] { 10m, "10.000" };

                yield return new object[] { 10.1m, "10.100" };

                yield return new object[] { 10.12m, "10.120" };

                yield return new object[] { 10.649m, "10.649" };
            }
        }

        [Theory]
        [MemberData(nameof(PriceValuesTestData.Get), MemberType = typeof(PriceValuesTestData))]
        public void Should_round_to_2_digits_on_serialization(decimal value, string expected)
        {
            var payload = new CountValueTestClass()
            {
                Value = value
            };

            var result = JsonSerializer.Serialize(payload, Create());

            Assert.NotNull(result);

            Assert.Equal($"{{\"Value\":{expected}}}", result);
        }


        [Theory]
        [MemberData(nameof(PriceValuesTestData.Get), MemberType = typeof(PriceValuesTestData))]
        public void Should_round_to_3_digits_on_deserialization(decimal value, string expected)
        {
            var payload = $"{{\"Value\":{expected}}}";


            var result = JsonSerializer.Deserialize<CountValueTestClass>(payload, Create());

            Assert.NotNull(result);
            Assert.Equal(value, (decimal)result!.Value);
        }
    }
}