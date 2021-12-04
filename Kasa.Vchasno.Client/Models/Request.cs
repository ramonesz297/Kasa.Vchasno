using System;
using System.Text.Json.Serialization;
using Kasa.Vchasno.Client.Enumerations;
using Kasa.Vchasno.Client.Models.Requests;

namespace Kasa.Vchasno.Client.Models
{
    public class Request
    {
        public Request(string token, RequestTypes type = RequestTypes.Fiscal, string source = null, string device = null, string tag = "")
        {
            Token = token;
            Type = type;
            Source = source;
            Device = device;
            Tag = tag;
        }

        /// <summary>
        /// Version of the json scheme
        /// </summary>
        [JsonPropertyName("ver")]
        public SchemaVersions Version { get; set; } = SchemaVersions.Version_6;

        /// <summary>
        /// Source of the request
        /// </summary>
        [JsonPropertyName("source")]
        public string Source { get; set; }

        [JsonPropertyName("device")]
        public string Device { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; }

        [JsonPropertyName("dt")]
        public DateTimeOffset CratedAt { get; set; } = DateTimeOffset.Now;

        [JsonPropertyName("token")]
        public string Token { get; set; }

        /// <summary>
        /// need_pf_img
        /// </summary>
        [JsonPropertyName("need_pf_img")]
        public PrintingResultTypes NeedImg { get; set; }

        /// <summary>
        /// need_pf_img
        /// </summary>
        [JsonPropertyName("need_pf_pdf")]
        public PrintingResultTypes NeedPdf { get; set; }

        /// <summary>
        /// need_pf_txt
        /// </summary>
        [JsonPropertyName("need_pf_txt")]
        public PrintingResultTypes NeedTxt { get; set; }


        [JsonPropertyName("type")]
        public RequestTypes Type { get; set; } = RequestTypes.Fiscal;


        [JsonPropertyName("fiscal")]
        public FiscalRequest Fiscal { get; set; }
    }
}