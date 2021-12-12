using System;
using System.Globalization;

namespace Kasa.Vchasno.Client.JsonConverters
{
    internal static class VchasnoDateTimeOffsetReader
    {
        internal const string Format = "yyyyMMddHHmmssFFF";
        internal const string AdditionalFormat = "dd-MM-yyyy HH:mm:ss";

        internal static DateTimeOffset Parse(string? input)
        {
            if (DateTimeOffset.TryParseExact(input, Format, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var result))
            {
                return result;
            }
            else if (DateTimeOffset.TryParseExact(input, AdditionalFormat, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out result))
            {
                return result;
            }
            else
            {
                return DateTimeOffset.MinValue;
            }
        }

    }
}