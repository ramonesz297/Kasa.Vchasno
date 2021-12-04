using System;

namespace Kasa.Vchasno.Client.ValueTypes
{
    public readonly struct PriceValue
    {
        private readonly decimal _value;

        public PriceValue(decimal value)
        {
            _value = Math.Round(value, 2);
        }

        public static implicit operator decimal(PriceValue price) => price._value;

        public static implicit operator PriceValue(decimal value) => new PriceValue(value);

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}