using System.Text.Json.Serialization;

namespace Kasa.Vchasno.Client.Models.Requests
{
    public class NonFiscalInformation
    {
        /// <summary>
        /// Free text user information
        /// </summary>
        [JsonPropertyName("t")]
        public string? T { get; set; }

        [JsonPropertyName("qr_type")]
        public QrTypes QrType { get; set; }
    }
}