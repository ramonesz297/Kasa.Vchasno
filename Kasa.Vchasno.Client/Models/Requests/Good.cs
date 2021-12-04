using System.Text.Json.Serialization;
using Kasa.Vchasno.Client.ValueTypes;

namespace Kasa.Vchasno.Client.Models.Requests
{
    public class Good
    {
        [JsonPropertyName("code")]
        public string Code { get; set; } 

        [JsonPropertyName("code1")]
        public string Code1 { get; set; }

        [JsonPropertyName("code2")]
        public string Code2 { get; set; }

        [JsonPropertyName("code3")]
        public string Code3 { get; set; }

        [JsonPropertyName("code_a")]
        public string CodeA { get; set; }

        [JsonPropertyName("code_aa")]
        public string[] CodeAA { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("cnt")]
        public CountValue Count { get; set; }

        [JsonPropertyName("price")]
        public PriceValue Price { get; set; }

        [JsonPropertyName("disc")]
        public PriceValue Discount { get; set; }

        [JsonPropertyName("cost")]
        public PriceValue? Cost { get; set; }

        /// <summary>
        /// Default is - without VAT (code = 2)
        /// </summary>
        [JsonPropertyName("taxgrp")]
        public int TaxGroup { get; set; } = DefaultVchasnoTaxGroups.Without_VAT;

        [JsonPropertyName("comment")]
        public string Comment { get; set; }
    }
}