using Application.Common.Messages.Bucket.Responses;
using System.Collections.Generic;
using Application.Common.Messages.Bucket.Requests;
using Mock.Model.Entities;

namespace Mock.Services.Interfaces
{
    public interface IBucketService
    {
         List<Bucket> GetBucketList(BucketListRequest request);
         Bucket GetBucket(BucketDetailRequest request);
         
        AddInvoicesResponse AddInvoices(AddInvoicesRequest request);
         RemoveInvoicesResponse RemoveInvoices(RemoveInvoicesRequest request);
         DeleteBucketResponse DeleteBucket(DeleteBucketRequest request);
         SubmitBucketResponse SubmitBucket(SubmitBucketRequest request);
         UpdateDateResponse UpdateDate(UpdateDateRequest request);


    }
}
