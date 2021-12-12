using System;
using System.Text.Json.Serialization;

namespace Kasa.Vchasno.Client.Models.Responses
{
    public class BaseInfoResponse
    {
        [JsonPropertyName("fisid")]
        public string? Fisid { get; set; }
    }
}