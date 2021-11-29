using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Model.Enums
{
    public enum RemoveInvoicesOperationResult
    {
        BucketNotFound = 1,
        InvoiceItemsEmpty,
        InvoiceItemNotFound,
        Success
    }
}
