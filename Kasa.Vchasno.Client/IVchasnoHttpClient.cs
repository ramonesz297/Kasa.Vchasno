using Kasa.Vchasno.Client.Models;
using Kasa.Vchasno.Client.Models.Requests;
using Kasa.Vchasno.Client.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Kasa.Vchasno.Client
{
    public interface IVchasnoHttpClient
    {
        Task<Response<TInfoResponse>?> CoreExecuteAsync<TInfoResponse>(BaseRequest request, CancellationToken cancellationToken = default) where TInfoResponse : BaseInfoResponse;
        Task<Response<TInfoResponse>?> CoreExecuteAsync<TInfoResponse>(Request request, CancellationToken cancellationToken = default) where TInfoResponse : BaseInfoResponse;
        Task<CommonSettings?> GetSettingsAsync(CancellationToken cancellationToken = default);
        Task<Response<FiscalRegisterStatusResponse>?> GetStatusAsync(CancellationToken cancellationToken = default);
        Task<Response<DefaultInfoResponse>?> OpenShiftAsync(string tag = "", CancellationToken cancellationToken = default);
        Task<Response<TResponse>?> RepeatAsync<TResponse>(string tag, CancellationToken cancellationToken = default) where TResponse : BaseInfoResponse;
        Task<Response<ReceiptResponse>?> ReturnAsync(Receipt receipt, string tag = "", CancellationToken cancellationToken = default);
        Task<Response<ReceiptResponse>?> SaleAsync(Receipt receipt, string tag = "", CancellationToken cancellationToken = default);
        Task<Response<DefaultInfoResponse>?> ServiceInAsync(ServiceCash cash, string tag = "", CancellationToken cancellationToken = default);
        Task<Response<DefaultInfoResponse>?> ServiceOutAsync(ServiceCash cash, string tag = "", CancellationToken cancellationToken = default);
        Task<Response<ReportResponse>?> XReportAsync(string tag = "", CancellationToken cancellationToken = default);
        Task<Response<ReportResponse>?> ZReportAsync(string tag = "", CancellationToken cancellationToken = default);
    }
}