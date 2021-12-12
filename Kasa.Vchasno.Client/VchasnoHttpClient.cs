using Kasa.Vchasno.Client.Models;
using Kasa.Vchasno.Client.Models.Requests;
using Kasa.Vchasno.Client.Models.Responses;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Kasa.Vchasno.Client
{
    public sealed class VchasnoHttpClient : IVchasnoHttpClient
    {
        private readonly HttpClient _client;
        private readonly IJsonSerializerOptionsProvider _optionsProvider;
        private readonly IVchasnoRequesFactory _vchasnoRequesFactory;
        public VchasnoHttpClient(HttpClient client, IJsonSerializerOptionsProvider optionsProvider, IVchasnoRequesFactory vchasnoRequesFactory)
        {
            _client = client;
            _optionsProvider = optionsProvider;
            _vchasnoRequesFactory = vchasnoRequesFactory;
        }

        public async Task<Response<TInfoResponse>?> CoreExecuteAsync<TInfoResponse>(Request request, CancellationToken cancellationToken = default)
            where TInfoResponse : BaseInfoResponse
        {
            using var response = await _client.PostAsJsonAsync("dm/execute", request, _optionsProvider.Options, cancellationToken).ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<Response<TInfoResponse>?>(_optionsProvider.Options, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Response<TInfoResponse>?> CoreExecuteAsync<TInfoResponse>(BaseRequest request, CancellationToken cancellationToken = default)
            where TInfoResponse : BaseInfoResponse
        {
            using var response = await _client.PostAsJsonAsync("dm/execute", request, _optionsProvider.Options, cancellationToken).ConfigureAwait(false);
            return await response.Content.ReadFromJsonAsync<Response<TInfoResponse>?>(_optionsProvider.Options, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Response<TResponse>?> RepeatAsync<TResponse>(string tag, CancellationToken cancellationToken = default)
            where TResponse : BaseInfoResponse
        {
            var request = _vchasnoRequesFactory.Repeat(tag);
            return await CoreExecuteAsync<TResponse>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Response<ReceiptResponse>?> SaleAsync(Receipt receipt, string tag = "", CancellationToken cancellationToken = default)
        {
            var request = _vchasnoRequesFactory.Sale(receipt, tag);

            return await CoreExecuteAsync<ReceiptResponse>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Response<ReceiptResponse>?> ReturnAsync(Receipt receipt, string tag = "", CancellationToken cancellationToken = default)
        {
            var request = _vchasnoRequesFactory.Return(receipt, tag);

            return await CoreExecuteAsync<ReceiptResponse>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Response<DefaultInfoResponse>?> ServiceInAsync(ServiceCash cash, string tag = "", CancellationToken cancellationToken = default)
        {
            var request = _vchasnoRequesFactory.ServiceIn(cash, tag);

            return await CoreExecuteAsync<DefaultInfoResponse>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Response<DefaultInfoResponse>?> ServiceOutAsync(ServiceCash cash, string tag = "", CancellationToken cancellationToken = default)
        {
            var request = _vchasnoRequesFactory.ServiceOut(cash, tag);

            return await CoreExecuteAsync<DefaultInfoResponse>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Response<DefaultInfoResponse>?> OpenShiftAsync(string tag = "", CancellationToken cancellationToken = default)
        {
            var request = _vchasnoRequesFactory.OpenShift(tag);

            return await CoreExecuteAsync<DefaultInfoResponse>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Response<ReportResponse>?> ZReportAsync(string tag = "", CancellationToken cancellationToken = default)
        {
            var request = _vchasnoRequesFactory.ZReport(tag);

            return await CoreExecuteAsync<ReportResponse>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Response<ReportResponse>?> XReportAsync(string tag = "", CancellationToken cancellationToken = default)
        {
            var request = _vchasnoRequesFactory.XReport(tag);

            return await CoreExecuteAsync<ReportResponse>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<Response<FiscalRegisterStatusResponse>?> GetStatusAsync(CancellationToken cancellationToken = default)
        {
            var request = _vchasnoRequesFactory.Status();

            return await CoreExecuteAsync<FiscalRegisterStatusResponse>(request, cancellationToken).ConfigureAwait(false);
        }

        public async Task<CommonSettings?> GetSettingsAsync(CancellationToken cancellationToken = default)
        {
            var response = await _client.GetAsync("/dm/vchasno-kasa/api/v1/settings", cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CommonSettings>(_optionsProvider.Options, cancellationToken).ConfigureAwait(false);
        }
    }
}