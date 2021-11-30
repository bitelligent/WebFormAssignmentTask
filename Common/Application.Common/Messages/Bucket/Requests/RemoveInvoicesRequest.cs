using System.Collections.Generic;

namespace Application.Common.Messages.Bucket.Requests
{
    public class RemoveInvoicesRequest : BucketBaseRequest
    {
        public List<int> InvoiceIds { get; set; }
    }
}