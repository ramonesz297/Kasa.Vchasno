using Kasa.Vchasno.Client.ValueTypes;
using System.Collections.Generic;
using Xunit;

namespace Vchasno.Client.Tests
{
    public class PriceValueTests
    {
        public static class PriceValuesTestData
        {
            public static IEnumerable<object[]> Get()
            {
                yield return new object[] { 10m, 10.00m };

                yield return new object[] { 10.1m, 10.10m };

                yield return new object[] { 10.123m, 10.12m };

                yield return new object[] { 10.127m, 10.13m };

                yield return new object[] { 10.627999999m, 10.63m };
            }
        }

        [Theory]
        [MemberData(nameof(PriceValuesTestData.Get), MemberType = typeof(PriceValuesTestData))]
        public void Shoud_implicit_convert_and_round_from_decimal(decimal value, decimal expected)
        {
            PriceValue pv = value;

            Assert.Equal(expected, (decimal)pv);
        }
    }
}