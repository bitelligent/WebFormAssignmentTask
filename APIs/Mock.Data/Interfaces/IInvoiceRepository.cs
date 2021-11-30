using System.Collections.Generic;
using Mock.Model.Entities;
using Mock.Model.Enums;

namespace Mock.Data.Interfaces
{
    public interface IInvoiceRepository
    {
        List<SupplierInvoice> GetPendingInvoices();

    }
}
