using System;
using System.Collections.Generic;
using Mock.Model.Entities;
using Mock.Model.Enums;

namespace Mock.Data.Interfaces
{
    public interface IBucketRepository
    {
         List<Bucket> GetBucketList();
         Bucket GetBucket(int id);

         AddInvoicesOperationResult AddInvoices(int id, List<int> invoiceIds);
         RemoveInvoicesOperationResult RemoveInvoices(int id, List<int> invoiceIds);
         DeleteBucketOperationResult DeleteBucket(int id);
         SubmitBucketOperationResult SubmitBucket(int id);
    }
}
