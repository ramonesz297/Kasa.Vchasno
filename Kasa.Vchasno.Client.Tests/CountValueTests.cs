using Kasa.Vchasno.Client.ValueTypes;
using System.Collections.Generic;
using Xunit;

namespace Vchasno.Client.Tests
{
    public class CountValueTests
    {
        public static class CountValueTestData
        {
            public static IEnumerable<object[]> Get()
            {
                yield return new object[] { 10m, 10.00m };

                yield return new object[] { 10.1m, 10.10m };

                yield return new object[] { 10.1231m, 10.123m };

                yield return new object[] { 10.127m, 10.127m };

                yield return new object[] { 10.627999999m, 10.628m };
            }
        }

        [Theory]
        [MemberData(nameof(CountValueTestData.Get), MemberType = typeof(CountValueTestData))]
        public void Shoud_implicit_convert_and_round_from_decimal(decimal value, decimal expected)
        {
            CountValue pv = value;

            Assert.Equal(expected, (decimal)pv);
        }
    }
}