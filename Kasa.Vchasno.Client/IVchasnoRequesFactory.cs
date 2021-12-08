using Microsoft.Extensions.Options;
using Kasa.Vchasno.Client.Models;
using Kasa.Vchasno.Client.Models.Requests;

namespace Kasa.Vchasno.Client
{
    public interface IVchasnoRequesFactory
    {
        BaseRequest Repeat(string tag);
        Request OpenShift(string tag = "");
        Request Return(Receipt receipt, string tag = "");
        Request Sale(Receipt receipt, string tag = "");
        Request ServiceIn(ServiceCash receipt, string tag = "");
        Request ServiceOut(ServiceCash receipt, string tag = "");
        Request XReport(string tag = "");
        Request ZReport(string tag = "");
    }
}