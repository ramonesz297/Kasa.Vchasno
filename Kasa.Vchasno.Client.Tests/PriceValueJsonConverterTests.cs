using Kasa.Vchasno.Client.JsonConverters;
using Kasa.Vchasno.Client.ValueTypes;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;

namespace Vchasno.Client.Tests
{
    public class PriceValueJsonConverterTests
    {
        class PriceValueTestClass
        {
            public PriceValue Value { get; set; }
        }

        private JsonSerializerOptions Create()
        {
            return new JsonSerializerOptions(JsonSerializerDefaults.General)
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                Converters =
                {
                    new PriceValueJsonConverter()
                }
            };
        }

        public static class PriceValuesTestData
        {
            public static IEnumerable<object[]> Get()
            {
                yield return new object[] { 10m, "10.00" };

                yield return new object[] { 10.1m, "10.10" };

                yield return new object[] { 10.13m, "10.13" };

                yield return new object[] { 10.69m, "10.69" };
            }
        }

        [Theory]
        [MemberData(nameof(PriceValuesTestData.Get), MemberType = typeof(PriceValuesTestData))]
        public void Should_round_to_2_digits_on_serialization(decimal value, string expected)
        {
            var payload = new PriceValueTestClass()
            {
                Value = value
            };

            var result = JsonSerializer.Serialize(payload, Create());

            Assert.NotNull(result);

            Assert.Equal($"{{\"Value\":{expected}}}", result);
        }


        [Theory]
        [MemberData(nameof(PriceValuesTestData.Get), MemberType = typeof(PriceValuesTestData))]
        public void Should_round_to_2_digits_on_deserialization(decimal value, string expected)
        {
            var payload = $"{{\"Value\":{expected}}}";


            var result = JsonSerializer.Deserialize<PriceValueTestClass>(payload, Create());

            Assert.NotNull(result);
            Assert.Equal(value, (decimal)result!.Value);
        }
    }
}