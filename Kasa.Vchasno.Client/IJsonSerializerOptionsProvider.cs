using System.Text.Json;

namespace Kasa.Vchasno.Client
{    
    public interface IJsonSerializerOptionsProvider
    {
        JsonSerializerOptions Options { get; }
    }
}