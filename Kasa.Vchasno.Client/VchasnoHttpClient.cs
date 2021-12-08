using Kasa.Vchasno.Client.Models;
using Kasa.Vchasno.Client.Models.Responses;
using System.Net.Http;
using System.Net.Http.Json;
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

        protected virtual async Task<Response<TInfoResponse>> ExecuteAsync<TRequest, TInfoResponse>(TRequest request, CancellationToken cancellationToken = default)
            where TInfoResponse : BaseInfoResponse
            where TRequest : BaseRequest
        {
            using (var response = await _client.PostAsJsonAsync("dm/execute", request, _optionsProvider.Options, cancellationToken).ConfigureAwait(false))
            {
                return await response.Content.ReadFromJsonAsync<Response<TInfoResponse>>(_optionsProvider.Options, cancellationToken).ConfigureAwait(false);
            }
        }

        public virtual async Task<Response<TResponseInfo>> ExecuteAsync<TResponseInfo>(Request request, CancellationToken cancellationToken = default)
            where TResponseInfo : BaseInfoResponse
        {
            return await ExecuteAsync<TResponseInfo>(request).ConfigureAwait(false);
        }

        public virtual async Task<Response<TResponseInfo>> ExecuteAsync<TResponseInfo>(BaseRequest request, CancellationToken cancellationToken = default)
            where TResponseInfo : BaseInfoResponse
        {
            return await ExecuteAsync<TResponseInfo>(request).ConfigureAwait(false);
        }

        public async Task<CommonSettings> GetSettingsAsync(CancellationToken cancellationToken = default)
        {
            var response = await _client.GetAsync("/dm/vchasno-kasa/api/v1/settings", cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CommonSettings>(_optionsProvider.Options, cancellationToken).ConfigureAwait(false);
        }
    }
}