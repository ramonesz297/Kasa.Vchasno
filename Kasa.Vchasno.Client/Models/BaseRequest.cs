using System.Text.Json.Serialization;

namespace Kasa.Vchasno.Client.Models
{

    /// <summary>
    /// Base request attrubutes
    /// also can be used for repeat request by tag
    /// </summary>
    public class BaseRequest
    {
        /// <summary>
        /// ctor for Base vchasno request
        /// </summary>
        /// <param name="token">fiscal register token (required)</param>
        /// <param name="device">name of fiscal register (required)</param>
        /// <param name="source"></param>
        /// <param name="tag"></param>
        public BaseRequest(string token, string device, string? source = null, string? tag = null)
        {
            Token = token;
            Device = device;
            Source = source;
            Tag = tag;
        }

        /// <summary>
        /// Fiscal register token
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; }

        /// <summary>
        /// Version of the json scheme
        /// </summary>
        [JsonPropertyName("ver")]
        public SchemaVersions Version { get; set; } = SchemaVersions.Version_6;

        /// <summary>
        /// Source of the request
        /// </summary>
        [JsonPropertyName("source")]
        public string? Source { get; set; }


        /// <summary>
        /// Name of the fiscal register
        /// </summary>
        [JsonPropertyName("device")]
        public string Device { get; set; }

        /// <summary>
        /// Uniq tag can be used as for repeat request
        /// as for transaction mode 
        /// </summary>
        [JsonPropertyName("tag")]
        public string? Tag { get; set; }
    }
}