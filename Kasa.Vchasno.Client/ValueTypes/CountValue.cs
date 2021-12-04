using System;

namespace Kasa.Vchasno.Client.ValueTypes
{
    public readonly struct CountValue
    {
        private readonly decimal _value;

        public CountValue(decimal value)
        {
            _value = Math.Round(value, 3);
        }

        public static implicit operator decimal(CountValue price) => price._value;

        public static implicit operator CountValue(decimal value) => new CountValue(value);

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}