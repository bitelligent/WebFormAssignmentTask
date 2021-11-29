using System;
using System.Collections.Generic;
using Mock.Model.Entities;

namespace Mock.Data.Interfaces
{
    public interface IBucketRepository
    {
        public List<Bucket> GetBucketList();
        public Bucket GetBucket(int Id);

        public void AddInvoices(int Id, List<int> InvoiceIds);
        public void RemoveInvoices(int Id, List<int> InvoiceIds);
        public void DeleteBucket();
        public void SubmitBucket();
    }
}
