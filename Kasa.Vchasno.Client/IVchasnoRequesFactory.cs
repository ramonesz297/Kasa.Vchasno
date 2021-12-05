using Microsoft.Extensions.Options;
using Kasa.Vchasno.Client.Models;
using Kasa.Vchasno.Client.Models.Requests;

namespace Kasa.Vchasno.Client
{
    public interface IVchasnoRequesFactory
    {
        Request OpenShift(string tag = "");
        Request Return(Receipt receipt, string tag = "");
        Request Sale(Receipt receipt, string tag = "");
        Request ServiceIn(ServiceCash receipt, string tag = "");
        Request ServiceOut(ServiceCash receipt, string tag = "");
        Request XReport(string tag = "");
        Request ZReport(string tag = "");
    }

    public class VchasnoRequesFactory : IVchasnoRequesFactory
    {
        private readonly VchasnoOptions _options;

        public VchasnoRequesFactory(IOptionsSnapshot<VchasnoOptions> options)
        {
            _options = options.Value;
        }

        protected Request BuildBaseRequest(string tag = "")
        {
            return new Request(_options.Token, RequestTypes.Fiscal, _options.Source, _options.Device, tag);
        }

        public Request Sale(Receipt receipt, string tag = "")
        {
            var r = BuildBaseRequest(tag);

            r.Fiscal = new FiscalRequest(FiscalRequestTaskTypes.SaleReceipt)
            {
                Receipt = receipt
            };

            return r;
        }


        public Request ServiceOut(ServiceCash receipt, string tag = "")
        {
            var r = BuildBaseRequest(tag);

            r.Fiscal = new FiscalRequest(FiscalRequestTaskTypes.ServiceOut)
            {
                Cash = receipt
            };

            return r;
        }


        public Request ServiceIn(ServiceCash receipt, string tag = "")
        {
            var r = BuildBaseRequest(tag);

            r.Fiscal = new FiscalRequest(FiscalRequestTaskTypes.ServiceIn)
            {
                Cash = receipt
            };

            return r;
        }


        public Request ZReport(string tag = "")
        {
            var r = BuildBaseRequest(tag);

            r.Fiscal = new FiscalRequest(FiscalRequestTaskTypes.ZReport);

            return r;
        }


        public Request XReport(string tag = "")
        {
            var r = BuildBaseRequest(tag);

            r.Fiscal = new FiscalRequest(FiscalRequestTaskTypes.XReport);

            return r;
        }

        public Request Return(Receipt receipt, string tag = "")
        {
            var r = BuildBaseRequest(tag);

            r.Fiscal = new FiscalRequest(FiscalRequestTaskTypes.ReturnReceipt)
            {
                Receipt = receipt
            };

            return r;
        }

        public Request OpenShift(string tag = "")
        {
            var r = new Request(_options.Token, RequestTypes.Fiscal, _options.Source, _options.Device, tag)
            {
                Fiscal = new FiscalRequest(FiscalRequestTaskTypes.OpenShift)
            };

            return r;
        }
    }

}