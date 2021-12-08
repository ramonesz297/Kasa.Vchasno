using Kasa.Vchasno.Client.Models;
using Kasa.Vchasno.Client.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Kasa.Vchasno.Client
{
    public interface IVchasnoHttpClient
    {
        Task<Response<TResponseInfo>> ExecuteAsync<TResponseInfo>(Request request, CancellationToken cancellationToken = default) where TResponseInfo : BaseInfoResponse;
        Task<Response<TResponseInfo>> ExecuteAsync<TResponseInfo>(BaseRequest request, CancellationToken cancellationToken = default) where TResponseInfo : BaseInfoResponse;
        Task<CommonSettings> GetSettingsAsync(CancellationToken cancellationToken = default);
    }
}