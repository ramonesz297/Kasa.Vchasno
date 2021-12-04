using System.Text.Json.Serialization;

namespace Kasa.Vchasno.Client.Models.Requests
{
    public class Cash
    {
        [JsonPropertyName("type")]
        public PaymentTypes Type { get; set; } = PaymentTypes.Cash;

        [JsonPropertyName("sum")]
        public decimal Sum { get; set; }

        [JsonPropertyName("comment_up")]
        public string CommentUp { get; set; }

        [JsonPropertyName("comment_down")]
        public string CommentDown { get; set; }
    }
}