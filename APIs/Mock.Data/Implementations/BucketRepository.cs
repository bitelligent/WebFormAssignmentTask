using System.Collections.Generic;
using System.Linq;
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
            //lets find bucket first 
            var bucket = GetBucket(id);

            //if not found then return not found status
            if (bucket == null) return AddInvoicesOperationResult.BucketNotFound;
          
            //check if 
            if (invoiceIds.Count == 0) return AddInvoicesOperationResult.InvoiceItemsEmpty;

            if(bucket.SupplierInvoices == null) bucket.SupplierInvoices = new List<SupplierInvoice>();

            foreach (var invoiceId in invoiceIds)
            {
                var bucketAlreadyContainsInvoice = bucket.SupplierInvoices.Count(i => i.Id == invoiceId) > 0;
                
                if (bucketAlreadyContainsInvoice) continue;
                
                
                    var pendingInvoiceItem = _dataStore.PendingInvoices.FirstOrDefault(p => p.Id == invoiceId);
                    if (pendingInvoiceItem == null) return AddInvoicesOperationResult.InvoiceItemNotFound;

                    bucket.SupplierInvoices.Add(pendingInvoiceItem);
                
                //remove invoice from the pending list
                _dataStore.PendingInvoices.Remove(pendingInvoiceItem);
            }

            return AddInvoicesOperationResult.Success;

        }

        public RemoveInvoicesOperationResult RemoveInvoices(int id, List<int> invoiceIds)
        {

            //lets find bucket first 
            var bucket = GetBucket(id);

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
                _dataStore.PendingInvoices.Add(bucketInvoice);
            }

            return RemoveInvoicesOperationResult.Success;


        }

        public DeleteBucketOperationResult DeleteBucket(int id)
        {
            var bucket = GetBucket(id);
            if (bucket == null) return DeleteBucketOperationResult.BucketNotFound;

            _dataStore.Buckets.Remove(bucket);

            return DeleteBucketOperationResult.Success;
        }

        public SubmitBucketOperationResult SubmitBucket(int id)
        {
            var bucket = GetBucket(id);
            if (bucket == null) return SubmitBucketOperationResult.BucketNotFound;

            bucket.Status = (int)BucketStatus.Submitted;

            return SubmitBucketOperationResult.Success;


        }

        public List<SupplierInvoice> GetPendingInvoices()
        {
            throw new System.NotImplementedException();
        }
    }
}
