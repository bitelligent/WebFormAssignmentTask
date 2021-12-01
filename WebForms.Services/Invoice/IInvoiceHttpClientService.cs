using Application.Common.Messages.Invoice.Response;

namespace WebForms.Services.Invoice
{
    public interface IInvoiceHttpClientService
    {
        PendingInvoiceListResponse GetPendingInvoices();
    }
}