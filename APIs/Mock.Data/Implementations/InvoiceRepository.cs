using System.Collections.Generic;
using System.Linq;
using Mock.Data.Interfaces;
using Mock.Model.Entities;
using Mock.Model.Enums;

namespace Mock.Data.Implementations
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private IMockDataStore _dataStore;

        public InvoiceRepository(IMockDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public List<SupplierInvoice> GetPendingInvoices()
        {
            return _dataStore.PendingInvoices;
        }
    }
}
