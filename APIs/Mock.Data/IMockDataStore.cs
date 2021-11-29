using System.Collections.Generic;
using Mock.Model.Entities;

namespace Mock.Data
{
    public interface IMockDataStore
    {
        List<SupplierInvoice> PendingInvoices { get; set; }
        List<Bucket> Buckets { get; set; }
        void InitilizeWithTestData();

        SupplierInvoice CreateInvoiceItem(int Id, string docReference,
            decimal totalAmount, string creditReference, string creditDebitFlag, int daySeed);

        Bucket CreateBucketItem(int Id, string title, int buyerComComId, int supplierComComId, string financeMethod , int status,bool isDue, int daysSeed);
    }
}