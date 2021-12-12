using System.Text.Json.Serialization;
using Kasa.Vchasno.Client.ValueTypes;

namespace Kasa.Vchasno.Client.Models.Requests
{
    public class Good
    {
        /// <summary>
        /// Good code
        /// </summary>
        [JsonPropertyName("code")]
        public string? Code { get; set; } 

        /// <summary>
        /// Bar code of the good
        /// </summary>
        [JsonPropertyName("code1")]
        public string? Code1 { get; set; }

        /// <summary>
        /// Additional good code (max length = 10)
        /// Ukrainian classification of goods for foreign economic activity
        /// </summary>
        [JsonPropertyName("code2")]
        public string? Code2 { get; set; }

        /// <summary>
        /// Additional good code
        /// State classifier of products and services
        /// </summary>
        [JsonPropertyName("code3")]
        public string? Code3 { get; set; }

        /// <summary>
        /// Excise stamp code of the goods
        /// </summary>
        [JsonPropertyName("code_a")]
        public string? CodeA { get; set; }

        /// <summary>
        /// Excise stamp codes of the goods
        /// if good has many codes
        /// </summary>
        [JsonPropertyName("code_aa")]
        public string[]? CodeAA { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Quantity of good (will be rounded to 3 digits)
        /// </summary>
        [JsonPropertyName("cnt")]
        public CountValue Count { get; set; }

        /// <summary>
        /// Final price of the good (will be rounded to 2 digits)
        /// might be empy (will be calculated  = (cost / count) - discount
        /// </summary>
        [JsonPropertyName("price")]
        public PriceValue? Price { get; set; }

        /// <summary>
        /// Total discount (will be rounded to 2 digits)
        /// </summary>
        [JsonPropertyName("disc")]
        public PriceValue Discount { get; set; }


        /// <summary>
        /// Total cost of the good without discount
        /// might be empty (Cost = (Price * Count)
        /// </summary>
        [JsonPropertyName("cost")]
        public PriceValue? Cost { get; set; }

        /// <summary>
        /// Default is - without VAT (code = 2)
        /// <see cref="DefaultVchasnoTaxGroups"/>
        /// </summary>
        [JsonPropertyName("taxgrp")]
        public int TaxGroup { get; set; } = DefaultVchasnoTaxGroups.Without_VAT;

        [JsonPropertyName("comment")]
        public string? Comment { get; set; }
    }
}