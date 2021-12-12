using System;
using System.Text.Json.Serialization;

namespace Kasa.Vchasno.Client.Models.Responses
{
    public class FiscalRegisterStatusResponse : DefaultInfoResponse
    {
        [JsonPropertyName("isFis")]
        public FiscalRegisterTypes FiscalRegisterType { get; set; } = FiscalRegisterTypes.Unknown;

        [JsonPropertyName("shift_status")]
        public ShiftStatuses ShiftStatus { get; set; } = ShiftStatuses.Unknown;

        [JsonPropertyName("shift_dt")]
        public DateTimeOffset? OpenedAt { get; set; }

        [JsonPropertyName("online_status")]
        public OnlineStatuses OnlineStatus { get; set; } = OnlineStatuses.Unknown;
        
        [JsonPropertyName("sign_status")]
        public SignStatuses SignStatus { get; set; } = SignStatuses.Unknown;

        [JsonPropertyName("safe")]
        public decimal Safe { get; set; }
    }
}