using System.Text.Json.Serialization;

namespace Kasa.Vchasno.Client.Models.Responses
{
    public class ReceiptResponse : DefaultInfoResponse
    {
        [JsonPropertyName("docno")]
        public string DocNumber { get; set; } = null!;

        [JsonPropertyName("qr")]
        public string Qr { get; set; } = null!;

        [JsonPropertyName("cancelid")]
        public string CancelId { get; set; } = null!;

        [JsonPropertyName("isprint")]
        public PrintingResults IsPrint { get; set; }

        [JsonPropertyName("safe")]
        public double Safe { get; set; }
    }
}