using System;
using System.Collections.Generic;
using Mock.Model.Entities;
using Mock.Model.Enums;

namespace Mock.Data
{
    public class MockDataStore : IMockDataStore
    {
        public List<SupplierInvoice> PendingInvoices { get; set; }
        public List<Bucket> Buckets { get; set; }

        public MockDataStore()
        {

            InitilizeWithTestData();
        }

        public void InitilizeWithTestData()
        {
            if(PendingInvoices == null) PendingInvoices = new List<SupplierInvoice>();
            if (Buckets == null) Buckets = new List<Bucket>();

            if (Buckets.Count > 0) return; // already initlized

            Buckets.Add(CreateBucketItem(1, "WHOLE - 185158 - 07/06/2021", 185158,3,FinanceMethod.WHOLE, (int)BucketStatus.Pending, true, -1));
            Buckets.Add(CreateBucketItem(1, "WHOLE - 185159 - 08/06/2021", 185159, 3, FinanceMethod.WHOLE, (int)BucketStatus.Pending, true, -1));
            Buckets.Add(CreateBucketItem(1, "WHOLE - 185161 - 09/06/2021", 185161, 3, FinanceMethod.WHOLE, (int)BucketStatus.Pending, true, -1));

            PendingInvoices.Add(CreateInvoiceItem(20, "B21321", 735.89m,"", InvoiceFlags.DEBIT ,2));
            PendingInvoices.Add(CreateInvoiceItem(20, "B21322", 35.89m, "", InvoiceFlags.DEBIT, 3));
            PendingInvoices.Add(CreateInvoiceItem(20, "B21323", 675.89m, "", InvoiceFlags.DEBIT, 4));
            PendingInvoices.Add(CreateInvoiceItem(20, "B21324", 5.89m, "", InvoiceFlags.DEBIT, 5));
            PendingInvoices.Add(CreateInvoiceItem(20, "B21325", 359.89m, "", InvoiceFlags.DEBIT, 6));
            PendingInvoices.Add(CreateInvoiceItem(20, "B21326", 7365.89m, "", InvoiceFlags.DEBIT, 7));
            PendingInvoices.Add(CreateInvoiceItem(20, "B21327", 7.89m, "", InvoiceFlags.DEBIT, 8));
            PendingInvoices.Add(CreateInvoiceItem(20, "B21328", 74.89m, "", InvoiceFlags.DEBIT, 9));
            PendingInvoices.Add(CreateInvoiceItem(20, "B21400", 33.89m, "", InvoiceFlags.DEBIT, 10));
            PendingInvoices.Add(CreateInvoiceItem(20, "B21401", 75.89m, "", InvoiceFlags.DEBIT, 11));
            PendingInvoices.Add(CreateInvoiceItem(20, "B21402", 190.89m, "", InvoiceFlags.DEBIT, 12));
            PendingInvoices.Add(CreateInvoiceItem(20, "B21403", 100.89m, "", InvoiceFlags.DEBIT, 13));
        }

        public SupplierInvoice CreateInvoiceItem(int Id, string docReference,
            decimal totalAmount, string creditReference, string creditDebitFlag, int daySeed)
        {
            return new SupplierInvoice()
            {
                Id = Id,
                DocReference = docReference,
                CreditReference = creditReference,
                InvoiceDate = DateTime.Now.AddDays(-daySeed),
                DueDate = DateTime.Now.AddDays(daySeed + 10),
                TotalAmount = totalAmount,

            };
        }

        public Bucket CreateBucketItem(int Id, string title, int buyerComComId, int supplierComComId, string financeMethod , int status,bool isDue, int daysSeed)
        {
            return new Bucket
            {
                Id = Id,
                BuyerComComId = buyerComComId,
                SupplierComComId = supplierComComId,
                FinanceMethod = financeMethod,
                IsDuedate = false,
                FutureFinanceDate = DateTime.Now.AddDays(10),
                Status = status,
                DateInserted = DateTime.Now.AddDays(-daysSeed),
                DateUpdated = DateTime.Now.AddDays(-daysSeed),
                SupplierInvoices = new List<SupplierInvoice>()
            };
        }
    }
}
