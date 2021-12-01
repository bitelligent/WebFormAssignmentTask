using Application.Common.Messages.Bucket.Requests;
using Application.Common.Messages.Bucket.Responses;

namespace WebForms.Services.Bucket
{
    public interface IBucketHttpClientService
    {
        BucketListResponse BucketList();
        AddInvoicesResponse AddInvoicesToBucket(AddInvoicesRequest request);
        DeleteBucketResponse DeleteBucket(DeleteBucketRequest request);
        SubmitBucketResponse SubmitBucket(SubmitBucketRequest request);
        UpdateDateResponse UpdateDate(UpdateDateRequest request);
        RemoveInvoicesResponse RemoveInvoicesToBucket(RemoveInvoicesRequest request);
        BucketDetailResponse GetBucketDetails(int bucketId);
    }
}