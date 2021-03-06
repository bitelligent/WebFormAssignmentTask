using System.Collections.Generic;
using Application.Common.Messages.Bucket.Responses;
using Application.Common.ViewModels;

namespace Application.Common.Messages.Invoice.Response
{
    public class PendingInvoiceListResponse 
    {
        public bool Success { get; set; }

        public  string ErrorMessage { get; set; }
        public List<InvoiceViewModel> PendingInvoices { get; set; }
    }
}