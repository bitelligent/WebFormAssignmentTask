namespace Application.Common.Messages.Bucket.Responses
{
    public enum RemoveInvoicesOperationResult
    {
        BucketNotFound = 1,
        InvoiceItemsEmpty,
        InvoiceItemNotFound,
        Success
    }
}
