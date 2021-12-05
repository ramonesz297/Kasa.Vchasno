using System.Text.Json.Serialization;

namespace Kasa.Vchasno.Client.Models.Responses
{
    public class CommonSettings
    {
        [JsonPropertyName("supmail")]
        public string SuppportEail { get; set; }

        [JsonPropertyName("logdays")]
        public long? LogDays { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("autoupdate")]
        public bool? Autoupdate { get; set; }

        [JsonPropertyName("autoupdatetime")]
        public string AutoupdateTime { get; set; }

        [JsonPropertyName("extAccess")]
        public bool? ExternalAccess { get; set; }

        [JsonPropertyName("packdays")]
        public long? Packagedays { get; set; }

        [JsonPropertyName("pf_charcount")]
        public long? PrintingFormCharCount { get; set; }

        [JsonPropertyName("pf_charwidth")]
        public long? PrintingFormPixelCount { get; set; }

        [JsonPropertyName("pf_astext")]
        public bool? PrintingFormAsText { get; set; }

        [JsonPropertyName("pf_asimage")]
        public bool? PrintingFormAsImage { get; set; }

        [JsonPropertyName("pf_aspdf")]
        public bool? PrintingFormAsPDF { get; set; }

        [JsonPropertyName("pf_del_custom")]
        public bool? DelCustomPrintingForm { get; set; }


    }
}