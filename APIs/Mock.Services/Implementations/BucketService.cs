using System.Collections.Generic;
using Application.Common.Messages.Bucket.Requests;
using Application.Common.Messages.Bucket.Responses;
using Mock.Data.Interfaces;
using Mock.Model.Entities;
using Mock.Model.Enums;
using Mock.Services.Interfaces;

namespace Mock.Services.Implementations
{
    public class BucketService : IBucketService
    {
        private readonly IBucketRepository _bucketRepository;
       
        public BucketService(IBucketRepository bucketRepository)
        {
            _bucketRepository = bucketRepository;
        }
    

        public List<Bucket> GetBucketList(BucketListRequest request)
        {
            
          
           return _bucketRepository.GetBucketList();
           
        }

        public Bucket GetBucket(BucketDetailRequest request)
        {
            return _bucketRepository.GetBucket(request.BasketId);
        }

        public AddInvoicesResponse AddInvoices(AddInvoicesRequest request)
        {
            var response = new AddInvoicesResponse();

            var addInvoicesOperation = _bucketRepository.AddInvoices(request.BasketId, request.InvoiceIds);

            if (addInvoicesOperation == AddInvoicesOperationResult.Success)
                response.Success = true;
            if (addInvoicesOperation == AddInvoicesOperationResult.BucketNotFound)
                response.ErrorMessage = "Bucket Not Found";
            if (addInvoicesOperation == AddInvoicesOperationResult.InvoiceItemNotFound)
                response.ErrorMessage = "Invoice Item(s) Not Found";
            if (addInvoicesOperation == AddInvoicesOperationResult.InvoiceItemsEmpty)
                response.ErrorMessage = "Invoice Item(s) Empty";

            return response;
        }

        public RemoveInvoicesResponse RemoveInvoices(RemoveInvoicesRequest request)
        {
            var response = new RemoveInvoicesResponse();

            var removeInvoicesOperation = _bucketRepository.RemoveInvoices(request.BasketId,request.InvoiceIds);

            if (removeInvoicesOperation == RemoveInvoicesOperationResult.Success)
                response.Success = true;
            if (removeInvoicesOperation == RemoveInvoicesOperationResult.BucketNotFound)
                response.ErrorMessage = "Bucket Not Found";
            if (removeInvoicesOperation == RemoveInvoicesOperationResult.InvoiceItemNotFound)
                response.ErrorMessage = "Invoice Item(s) Not Found";
            if (removeInvoicesOperation == RemoveInvoicesOperationResult.InvoiceItemsEmpty)
                response.ErrorMessage = "Invoice Item(s) Empty";

            return response;
        }

        public DeleteBucketResponse DeleteBucket(DeleteBucketRequest request)
        {

            var response = new DeleteBucketResponse();

            var deleteBucketResult = _bucketRepository.DeleteBucket(request.BasketId);

            if (deleteBucketResult == DeleteBucketOperationResult.Success)
                response.Success = true;
            if (deleteBucketResult == DeleteBucketOperationResult.BucketNotFound)
                response.ErrorMessage = "Bucket Not Found";

            return response;
        }

        public SubmitBucketResponse SubmitBucket(SubmitBucketRequest request)
        { 
            
            var response = new SubmitBucketResponse();

           var submitBucketResult = _bucketRepository.SubmitBucket(request.BasketId);

           if (submitBucketResult == SubmitBucketOperationResult.Success)
               response.Success = true;
           
           if(submitBucketResult == SubmitBucketOperationResult.BucketNotFound)
               response.ErrorMessage = "Bucket Not Found";

           
           return response;


        }
    }
}
