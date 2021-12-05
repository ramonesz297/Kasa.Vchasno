using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kasa.Vchasno.Client.Models.Requests
{
    public class FiscalRequest
    {
        public FiscalRequest(FiscalRequestTaskTypes task)
        {
            Task = task;
        }

        [JsonPropertyName("task")]
        public FiscalRequestTaskTypes Task { get; set; }

        [JsonPropertyName("cashier")]
        public string Cashier { get; set; }

        [JsonPropertyName("receipt")]
        public Receipt Receipt { get; set; }

        [JsonPropertyName("cash")]
        public ServiceCash Cash { get; set; }

        [JsonPropertyName("n_from")]
        public int? NumberFrom { get; set; }

        [JsonPropertyName("n_to")]
        public int? NumberTo { get; set; }

        [JsonPropertyName("dt_from")]
        public int? DateFrom { get; set; }

        [JsonPropertyName("dt_to")]
        public int? DateTo { get; set; }

        [JsonPropertyName("lines")]
        public List<NonFiscalInformation> Lines { get; set; }

    }
}