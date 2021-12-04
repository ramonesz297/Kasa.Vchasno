using System.Text.Json.Serialization;

namespace Kasa.Vchasno.Client.Models.Responses
{
    public class ReceiptResponse : BaseInfoResponse
    {
        [JsonPropertyName("docno")]
        public string DocNumber { get; set; }

        [JsonPropertyName("qr")]
        public string Qr { get; set; }

        [JsonPropertyName("cancelid")]
        public string CancelId { get; set; }

        [JsonPropertyName("isprint")]
        public PrintingResults IsPrint { get; set; }

        [JsonPropertyName("safe")]
        public double Safe { get; set; }
    }
}