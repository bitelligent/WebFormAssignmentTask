using System;
using System.Collections.Generic;
using Mock.Data.Interfaces;
using Mock.Model.Entities;

namespace Mock.Data.Implementations
{
    public class BucketRepository : IBucketRepository
    {
        

        public List<Bucket> GetBucketList()
        {
            throw new NotImplementedException();
        }

        public Bucket GetBucket(int Id)
        {
            throw new NotImplementedException();
        }

        public void AddInvoices(int Id, List<int> InvoiceIds)
        {
            throw new NotImplementedException();
        }

        public void RemoveInvoices(int Id, List<int> InvoiceIds)
        {
            throw new NotImplementedException();
        }

        public void DeleteBucket()
        {
            throw new NotImplementedException();
        }

        public void SubmitBucket()
        {
            throw new NotImplementedException();
        }
    }
}
