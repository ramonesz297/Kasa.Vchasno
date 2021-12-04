using System.Text.Json;

namespace Kasa.Vchasno.Client
{    
    /// <summary>
    /// To override default options replace this service with 
    /// new implementation in DI container
    /// </summary>
    public interface IJsonSerializerOptionsProvider
    {
        JsonSerializerOptions Options { get; }
    }
}