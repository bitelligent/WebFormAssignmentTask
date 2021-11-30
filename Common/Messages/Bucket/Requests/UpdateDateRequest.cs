using System;

namespace Application.Common.Messages.Bucket.Requests
{
    public class UpdateDateRequest : BasketBaseRequest
    {
        public DateTime UpdateDate { get; set; }
    }
}