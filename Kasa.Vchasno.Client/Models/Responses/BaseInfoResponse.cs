using System;
using System.Text.Json.Serialization;

namespace Kasa.Vchasno.Client.Models.Responses
{
    public class BaseInfoResponse
    {
        [JsonPropertyName("dt")]
        public DateTimeOffset DateTime { get; set; }

        [JsonPropertyName("fisid")]
        public string Fisid { get; set; }

        [JsonPropertyName("doccode")]
        public string DocCode { get; set; }

        [JsonPropertyName("dataid")]
        public int? Dataid { get; set; }

        [JsonPropertyName("shift_link")]
        public int? ShiftLink { get; set; }

        [JsonPropertyName("cashier")]
        public string Cashier { get; set; }
    }
}