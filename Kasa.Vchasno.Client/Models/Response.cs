using System;
using System.Text.Json.Serialization;
using Kasa.Vchasno.Client.Models.Responses;

namespace Kasa.Vchasno.Client.Models
{
    public class Response<T> where T : BaseInfoResponse
    {
        [JsonPropertyName("ver")]
        public SchemaVersions Version { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("device")]
        public string Device { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("dt")]
        public DateTimeOffset CratedAt { get; set; }

        [JsonPropertyName("res_action")]
        public ResultActions ResultAction { get; set; }

        [JsonPropertyName("errortxt")]
        public string ErrorText { get; set; }

        [JsonPropertyName("task")]
        public FiscalRequestTaskTypes? Task { get; set; }

        public T Info { get; set; }

        [JsonPropertyName("pf_text")]
        public string Text { get; set; }

        [JsonPropertyName("pf_image")]
        public string Image { get; set; }

        [JsonPropertyName("pf_pdf")]
        public string PDF { get; set; }
    }
}