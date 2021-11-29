using System.Collections.Generic;

namespace Application.Common.Messages.Bucket.Requests
{
    public class RemoveInvoicesRequest : BasketBaseRequest
    {
        public List<int> InvoiceIds { get; set; }
    }
}