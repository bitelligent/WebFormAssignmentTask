using System;

namespace Application.Common.Messages.Bucket.Requests
{
    public class UpdateDateRequest : BucketBaseRequest
    {
        public DateTime UpdateDate { get; set; }
    }
}