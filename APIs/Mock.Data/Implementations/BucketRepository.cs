using System;
using System.Collections.Generic;
using System.Linq;
using Application.Common.Messages.Bucket.Responses;
using Mock.Data.Interfaces;
using Mock.Model.Entities;
using Mock.Model.Enums;

namespace Mock.Data.Implementations
{
    public class BucketRepository : IBucketRepository
    {
        private IMockDataStore _dataStore;

        public BucketRepository(IMockDataStore dataStore)
        {
            _dataStore = dataStore;
        }
        public List<Bucket> GetBucketList()
        {
            return _dataStore.Buckets;
        }

        public Bucket GetBucket(int id)
        {
            return _dataStore.Buckets.FirstOrDefault(e => e.Id == id);
        }

        public AddInvoicesOperationResult AddInvoices(int id, List<int> invoiceIds)
        {
            var bucketList = GetBucketList();
            var pendingInvoices = _dataStore.PendingInvoices;

            
            //lets find bucket first 
            var bucket = bucketList.FirstOrDefault(b => b.Id == id);

            //if not found then return not found status
            if (bucket == null) return AddInvoicesOperationResult.BucketNotFound;
          
            //check if 
            if (invoiceIds.Count == 0) return AddInvoicesOperationResult.InvoiceItemsEmpty;

            if(bucket.SupplierInvoices == null) bucket.SupplierInvoices = new List<SupplierInvoice>();

            foreach (var invoiceId in invoiceIds)
            {
                var bucketAlreadyContainsInvoice = bucket.SupplierInvoices.Count(i => i.Id == invoiceId) > 0;
                
                if (bucketAlreadyContainsInvoice) continue;
                
                
                    var pendingInvoiceItem = pendingInvoices.FirstOrDefault(p => p.Id == invoiceId);
                    if (pendingInvoiceItem == null) return AddInvoicesOperationResult.InvoiceItemNotFound;

                    bucket.SupplierInvoices.Add(pendingInvoiceItem);

                //remove invoice from the pending list
                pendingInvoices.Remove(pendingInvoiceItem);
            }

            _dataStore.WriteBucketsToFileDatabase(bucketList);
            _dataStore.WritePendingInvoicesToDatabase(pendingInvoices);

            return AddInvoicesOperationResult.Success;

        }

        public RemoveInvoicesOperationResult RemoveInvoices(int id, List<int> invoiceIds)
        {

            var bucketList = GetBucketList();
            var pendingInvoices = _dataStore.PendingInvoices;


            //lets find bucket first 
            var bucket = bucketList.FirstOrDefault(b => b.Id == id);

            //lets find bucket first 
           

            //if not found then return not found status
            if (bucket == null) return RemoveInvoicesOperationResult.BucketNotFound;

            //check if 
            if (invoiceIds.Count == 0) return RemoveInvoicesOperationResult.InvoiceItemsEmpty;

            //already empty so nothing to do
            if (bucket.SupplierInvoices.Count == 0) return  RemoveInvoicesOperationResult.Success;

            foreach (var invoiceId in invoiceIds)
            {
                var bucketInvoice = bucket.SupplierInvoices
                    .FirstOrDefault(i => i.Id == invoiceId);

                if (bucketInvoice == null) return RemoveInvoicesOperationResult.InvoiceItemNotFound;
                
                //remove bucket invoice
                bucket.SupplierInvoices.Remove(bucketInvoice);

                //put invoice item back into pending list
                pendingInvoices.Add(bucketInvoice);
            }

            _dataStore.WriteBucketsToFileDatabase(bucketList);
            _dataStore.WritePendingInvoicesToDatabase(pendingInvoices);

            return RemoveInvoicesOperationResult.Success;


        }

        public DeleteBucketOperationResult DeleteBucket(int id)
        {
            var bucketList = GetBucketList();

            var bucket = bucketList.FirstOrDefault(b => b.Id == id);
            if (bucket == null) return DeleteBucketOperationResult.BucketNotFound;

            bucketList.Remove(bucket);

            _dataStore.WriteBucketsToFileDatabase(bucketList);

            return DeleteBucketOperationResult.Success;
        }

        public SubmitBucketOperationResult SubmitBucket(int id)
        {
            var bucketList = GetBucketList();
            var bucket = bucketList.FirstOrDefault(b => b.Id == id);
           
            if (bucket == null) return SubmitBucketOperationResult.BucketNotFound;

            bucket.Status = (int)BucketStatus.Submitted;

            _dataStore.WriteBucketsToFileDatabase(bucketList);

            return SubmitBucketOperationResult.Success;



        }

   

        public UpdateDateOperationResult UpdateDate(int id, DateTime date)
        {
            var bucketList = GetBucketList();
            var bucket = bucketList.FirstOrDefault(b => b.Id == id);
            
            if (bucket == null) return UpdateDateOperationResult.BucketNotFound;

            bucket.FutureFinanceDate = date;

            _dataStore.WriteBucketsToFileDatabase(bucketList);

            return UpdateDateOperationResult.Success;

        }
    }
}
