using System.Collections.Generic;
using Application.Common.ViewModels;

namespace Application.Common.Messages.Bucket.Responses
{
    public class BucketListResponse : BasketBaseResponse
    {
        public List<BucketViewModel> Buckets { get; set; }
    }
}