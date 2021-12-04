using Kasa.Vchasno.Client.Models;
using Kasa.Vchasno.Client.Models.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Kasa.Vchasno.Client
{
    public interface IVchasnoHttpClient
    {
        Task<Response<T>> SendAsync<T>(Request request, CancellationToken cancellationToken = default) where T : BaseInfoResponse;
    }
}