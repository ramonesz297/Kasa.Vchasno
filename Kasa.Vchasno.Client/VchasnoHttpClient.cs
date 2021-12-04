using Kasa.Vchasno.Client.JsonConverters;
using Kasa.Vchasno.Client.Models;
using Kasa.Vchasno.Client.Models.Responses;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Kasa.Vchasno.Client
{
    public class VchasnoHttpClient : IVchasnoHttpClient
    {
        private readonly HttpClient _client;
        private readonly IJsonSerializerOptionsProvider _optionsProvider;
        public VchasnoHttpClient(HttpClient client, IJsonSerializerOptionsProvider optionsProvider)
        {
            _client = client;
            _optionsProvider = optionsProvider;
        }

        public virtual async Task<Response<T>> SendAsync<T>(Request request, CancellationToken cancellationToken = default) where T : BaseInfoResponse
        {
            using (var response = await _client.PostAsJsonAsync("dm/execute", request, _optionsProvider.Options, cancellationToken).ConfigureAwait(false))
            {
                return await response.Content.ReadFromJsonAsync<Response<T>>(_optionsProvider.Options, cancellationToken).ConfigureAwait(false);
            }
        }

    }
}