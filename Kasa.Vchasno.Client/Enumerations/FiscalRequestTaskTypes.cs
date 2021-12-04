namespace Kasa.Vchasno.Client.Models
{
    public enum FiscalRequestTaskTypes
    {
        OpenShift = 0,
        SaleReceipt = 1,
        ReturnReceipt = 2,
        ServiceIn = 3,
        ServiceOut = 4,
        ServiceReport = 5,
        XReport = 10,
        ZReport = 11,
        ConsolidatedZReportByNumbers = 12,
        ConsolidatedZReportByDates = 13,
        FiscalRegisterStatus = 18,
        ReturnFiscalRegisterNumber = 20,
        ReturnLastFiscalReceiptNumber = 21,
        RerunLastSuccessFiscalReceipt = 22
    }
}