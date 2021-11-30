using Application.Common.ViewModels;

namespace Application.Common.Messages.Bucket.Responses
{
    public class BucketDetailResponse : BasketBaseResponse
    {
        public BucketViewModel Bucket { set; get; }
    }
}