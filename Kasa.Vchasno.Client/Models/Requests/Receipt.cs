using System.Collections.Generic;
using System.Text.Json.Serialization;
using Kasa.Vchasno.Client.ValueTypes;

namespace Kasa.Vchasno.Client.Models.Requests
{
    public class Receipt
    {
        [JsonPropertyName("sum")]
        public PriceValue Sum { get; set; }

        [JsonPropertyName("round")]
        public PriceValue Round { get; set; }

        [JsonPropertyName("comment_up")]
        public string? CommentUp { get; set; }

        [JsonPropertyName("comment_down")]
        public string? CommentDown { get; set; }

        [JsonPropertyName("rows")]
        public List<Good> Rows { get; set; } = new List<Good>();

        [JsonPropertyName("pays")]
        public List<ReceiptPayment> Pays { get; set; } = new List<ReceiptPayment>();
    }
}