using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Runtime.Caching;
using System.Text.Json;
using Application.Common.ConfigSettings;
using System.Configuration;
using Mock.Model.Entities;
using Mock.Model.Enums;



namespace Mock.Data
{
    public class MockDataStore : IMockDataStore
    {
        private const string BucketKey = "CacheKeyBuckets";
        private const string PendingInvoicesKey = "CacheKeyPendingInvoices";
        public  List<SupplierInvoice> PendingInvoices { get; set; }
        public List<Bucket> Buckets { get; set; }

        public MockDataStore()
        {
            Buckets = PopulateBasketsFromFileDatabase();

            if (Buckets == null || Buckets.Count == 0)
                Buckets = PopulateBaskets();

            PendingInvoices = PopulatePendingInvoicesFromDatabase();

            if(PendingInvoices == null || PendingInvoices.Count == 0)
                PendingInvoices = PopulatePendingInvoices();
        }

        private List<SupplierInvoice> PopulatePendingInvoicesFromDatabase()
        {
            var config= new Config();
            try
            {
              var db =  File.ReadAllText(config.PendingInvoicesDatabaseFilePath());
              if (!string.IsNullOrEmpty(db))
              {
                  List<SupplierInvoice> invoices =
                      JsonSerializer.Deserialize<List<SupplierInvoice>>(db);
                  return invoices;
              }
            }
            catch (Exception e)
            {
                return null;
            }

            return null;
        }


        public void WritePendingInvoicesToDatabase(List<SupplierInvoice> invoices)
        {
            var config = new Config();
            try
            {
                string jsonString = JsonSerializer.Serialize(invoices);
                File.WriteAllText(config.PendingInvoicesDatabaseFilePath(), jsonString);

            }
            catch (Exception e)
            {
                
            }

            
        }

        private List<Bucket> PopulateBasketsFromFileDatabase()
        {

            var config = new Config();
            try
            {
                var db = File.ReadAllText(config.BucketDatabaseFilePath());
                if (!string.IsNullOrEmpty(db))
                {
                    List<Bucket> buckets =
                        JsonSerializer.Deserialize<List<Bucket>>(db);
                    return buckets;
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return null;
        }

        public void WriteBucketsToFileDatabase(List<Bucket> buckets)
        {
            var config = new Config();
            try
            {
                var path = AppDomain.CurrentDomain.BaseDirectory;

                string jsonString = JsonSerializer.Serialize(buckets);
                File.WriteAllText(config.BucketDatabaseFilePath(), jsonString);

            }
            catch (Exception e)
            {

            }
        }

        public List<Bucket> PopulateBaskets()
        {

            

            var buckets = new List<Bucket>();

            
            buckets.Add(CreateBucketItem(1, "WHOLE - 185158 - 07/06/2021", 185158,3,FinanceMethod.WHOLE, (int)BucketStatus.Pending, true, -1));
            buckets.Add(CreateBucketItem(2, "WHOLE - 185159 - 08/06/2021", 185159, 3, FinanceMethod.WHOLE, (int)BucketStatus.Pending, true, -1));
            buckets.Add(CreateBucketItem(3, "WHOLE - 185161 - 09/06/2021", 185161, 3, FinanceMethod.WHOLE, (int)BucketStatus.Pending, true, -1));
          
            WriteBucketsToFileDatabase(buckets);
            return buckets;
           
            

        }

        public List<SupplierInvoice> PopulatePendingInvoices()
        {


            var pendingInvoices = new List<SupplierInvoice>();

            pendingInvoices.Add(CreateInvoiceItem(21, "B21321", 735.89m, "", InvoiceFlags.DEBIT, 2));
            pendingInvoices.Add(CreateInvoiceItem(22, "B21322", 35.89m, "", InvoiceFlags.DEBIT, 3));
            pendingInvoices.Add(CreateInvoiceItem(23, "B21323", 675.89m, "", InvoiceFlags.DEBIT, 4));
            pendingInvoices.Add(CreateInvoiceItem(24, "B21324", 5.89m, "", InvoiceFlags.DEBIT, 5));
            pendingInvoices.Add(CreateInvoiceItem(25, "B21325", 359.89m, "Ref 1", InvoiceFlags.CREDIT, 6));
            pendingInvoices.Add(CreateInvoiceItem(26, "B21326", 7365.89m, "Ref 2", InvoiceFlags.DEBIT, 7));
            pendingInvoices.Add(CreateInvoiceItem(27, "B21327", 7.89m, "", InvoiceFlags.CREDIT, 8));
            pendingInvoices.Add(CreateInvoiceItem(28, "B21328", 74.89m, "", InvoiceFlags.DEBIT, 9));
            pendingInvoices.Add(CreateInvoiceItem(29, "B21400", 33.89m, "", InvoiceFlags.DEBIT, 10));
            pendingInvoices.Add(CreateInvoiceItem(30, "B21401", 75.89m, "", InvoiceFlags.DEBIT, 11));
            pendingInvoices.Add(CreateInvoiceItem(31, "B21402", 190.89m, "", InvoiceFlags.DEBIT, 12));
            pendingInvoices.Add(CreateInvoiceItem(32, "B21403", 100.89m, "", InvoiceFlags.DEBIT, 13));

            WritePendingInvoicesToDatabase(pendingInvoices);

            return pendingInvoices;
            


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
                CreditDebitFlag =creditDebitFlag

            };
        }

        public Bucket CreateBucketItem(int Id, string title, int buyerComComId, int supplierComComId, string financeMethod , int status,bool isDue, int daysSeed)
        {
            return new Bucket
            {
                Id = Id,
                BuyerComComId = buyerComComId,
                Title = title,
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
