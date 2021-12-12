using Microsoft.Extensions.Options;
using Kasa.Vchasno.Client.Models;
using Kasa.Vchasno.Client.Models.Requests;

namespace Kasa.Vchasno.Client
{
    public class VchasnoRequesFactory : IVchasnoRequesFactory
    {
        private readonly VchasnoOptions _options;

        public VchasnoRequesFactory(IOptionsSnapshot<VchasnoOptions> options)
        {
            _options = options.Value;
        }

        protected Request BuildBaseRequest(FiscalRequest? fiscal = null, string tag = "")
        {
            return new Request(_options.Token, _options.Device, RequestTypes.Fiscal, _options.Source, tag)
            {
                Fiscal = fiscal
            };
        }

        protected Request BuildBaseRequest(FiscalRequestTaskTypes fiscalRequestTaskType, string tag = "")
        {
            return new Request(_options.Token, _options.Device, RequestTypes.Fiscal, _options.Source, tag)
            {
                Fiscal = new FiscalRequest(fiscalRequestTaskType)
            };
        }

        /// <summary>
        /// Build repeat request
        /// </summary>
        /// <param name="tag">uniq teg of the request</param>
        /// <returns></returns>
        public virtual BaseRequest Repeat(string tag)
        {
            return new BaseRequest(_options.Token, _options.Device, _options.Source, tag);
        }

        public virtual Request Sale(Receipt receipt, string tag = "")
        {
            return BuildBaseRequest(new FiscalRequest(FiscalRequestTaskTypes.SaleReceipt)
            {
                Receipt = receipt
            }, tag);
        }

        public virtual Request ServiceOut(ServiceCash receipt, string tag = "")
        {
            return BuildBaseRequest(new FiscalRequest(FiscalRequestTaskTypes.ServiceOut)
            {
                Cash = receipt
            }, tag);
        }

        public virtual Request ServiceIn(ServiceCash receipt, string tag = "")
        {
            return BuildBaseRequest(new FiscalRequest(FiscalRequestTaskTypes.ServiceIn)
            {
                Cash = receipt
            }, tag);
        }

        public virtual Request ZReport(string tag = "")
        {
            return BuildBaseRequest(FiscalRequestTaskTypes.ZReport, tag);
        }

        public virtual Request FiscalRegisterStatus(string tag = "")
        {
            return BuildBaseRequest(FiscalRequestTaskTypes.FiscalRegisterStatus, tag);
        }

        public virtual Request XReport(string tag = "")
        {
            return BuildBaseRequest(FiscalRequestTaskTypes.XReport, tag);
        }

        public virtual Request Status(string tag = "")
        {
            return BuildBaseRequest(FiscalRequestTaskTypes.FiscalRegisterStatus, tag);
        }

        public virtual Request Return(Receipt receipt, string tag = "")
        {
            return BuildBaseRequest(new FiscalRequest(FiscalRequestTaskTypes.ReturnReceipt)
            {
                Receipt = receipt
            }, tag);
        }

        public virtual Request OpenShift(string tag = "")
        {
            return BuildBaseRequest(FiscalRequestTaskTypes.OpenShift, tag);
        }
    }

}