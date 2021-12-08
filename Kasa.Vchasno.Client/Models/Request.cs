using System;
using System.Text.Json.Serialization;
using Kasa.Vchasno.Client.Enumerations;
using Kasa.Vchasno.Client.Models.Requests;

namespace Kasa.Vchasno.Client.Models
{
    public class Request : BaseRequest
    {
        public Request(string token, string device, RequestTypes type = RequestTypes.Fiscal, string source = null, string tag = "")
            : base(token, device, source, tag)
        {
            Type = type;
        }

        [JsonPropertyName("dt")]
        public DateTimeOffset CratedAt { get; set; } = DateTimeOffset.Now;

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