using System.Collections.Generic;

namespace Application.Common.Messages.Bucket.Requests
{
    public class AddInvoicesRequest : BasketBaseRequest
    {
        public List<int> InvoiceIds { set; get; }

    }
}