using Application.Common.Messages.Bucket.Responses;
using System.Collections.Generic;
using Application.Common.Messages.Bucket.Requests;
using Application.Common.Messages.Invoice.Request;
using Mock.Model.Entities;

namespace Mock.Services.Interfaces
{
    public interface IInvoiceService
    {
         List<SupplierInvoice> PendingInvoices(PendingInvoiceListRequest request);
        


    }
}
