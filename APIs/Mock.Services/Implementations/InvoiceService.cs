using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Messages.Bucket.Requests;
using Application.Common.Messages.Invoice.Request;
using Mock.Data.Interfaces;
using Mock.Model.Entities;
using Mock.Services.Interfaces;

namespace Mock.Services.Implementations
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }
        public List<SupplierInvoice> PendingInvoices(PendingInvoiceListRequest request)
        {
           return  _invoiceRepository.GetPendingInvoices();
        }
    }
}
