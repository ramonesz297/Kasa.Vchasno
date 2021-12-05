using Kasa.Vchasno.Client.ValueTypes;
using System.Text.Json.Serialization;

namespace Kasa.Vchasno.Client.Models.Requests
{
    public class ServiceCash
    {
        public ServiceCash(decimal sum, PaymentTypes type = PaymentTypes.Cash)
        {
            Sum = sum;
            Type = type;
        }

        [JsonPropertyName("type")]
        public PaymentTypes Type { get; }

        [JsonPropertyName("sum")]
        public PriceValue Sum { get; }

        [JsonPropertyName("comment_up")]
        public string CommentUp { get; set; }

        [JsonPropertyName("comment_down")]
        public string CommentDown { get; set; }
    }
}