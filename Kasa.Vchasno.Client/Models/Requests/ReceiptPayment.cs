using System.Text.Json.Serialization;
using Kasa.Vchasno.Client.ValueTypes;

namespace Kasa.Vchasno.Client.Models.Requests
{
    public class ReceiptPayment
    {
        public ReceiptPayment(PaymentTypes type, PriceValue sum)
        {
            Type = type;
            Sum = sum;
        }

        [JsonPropertyName("type")]
        public PaymentTypes Type { get; set; }

        [JsonPropertyName("sum")]
        public PriceValue Sum { get; set; }

        /// <summary>
        /// Default value is - 'грн'
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; } = "грн";

        [JsonPropertyName("comment")]
        public string Comment { get; set; }

        [JsonPropertyName("change")]
        public decimal Change { get; set; }


        /// <summary>
        /// Name of the payment system (for terminal payments) 
        /// </summary>
        [JsonPropertyName("paysys")]
        public string Paysys { get; set; }

        /// <summary>
        /// Transaction Code of the payment system  (for terminal payments) 
        /// </summary>
        [JsonPropertyName("rrn")]
        public string Rrn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("cardmask")]
        public string Cardmask { get; set; }

        [JsonPropertyName("term_id")]
        public string TermId { get; set; }

        [JsonPropertyName("bank_id")]
        public string BankId { get; set; }

        [JsonPropertyName("auth_code")]
        public string AuthCode { get; set; }
    }
}