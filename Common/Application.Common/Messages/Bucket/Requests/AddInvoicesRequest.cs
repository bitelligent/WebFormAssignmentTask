using System.Collections.Generic;

namespace Application.Common.Messages.Bucket.Requests
{
    public class AddInvoicesRequest : BucketBaseRequest
    {
        public List<int> InvoiceIds { set; get; }

    }
}