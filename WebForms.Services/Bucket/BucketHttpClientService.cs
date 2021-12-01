using Application.Common.Messages.Bucket.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Application.Common.ConfigSettings;
using Application.Common.Messages.Bucket.Requests;
using RestSharp;
using WebForms.Services.Common;

namespace WebForms.Services.Bucket
{
    public class BucketHttpClientService : IBucketHttpClientService
    {

       

        public  BucketListResponse BucketList()
        {
            var config = new Config();
            var response = new BucketListResponse();
            var baseUrl = config.BucketBaseApiEndPointUrl();
            var bucketListEndPoint = config.BucketListApiEndPointUrl();
            try
            {
                var restClient = new HttpRestClientActivity();
                response =  restClient.RestActivity<BucketListResponse>(baseUrl, bucketListEndPoint, Method.GET);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.Message;
            }

            return response;


        }



        public AddInvoicesResponse AddInvoicesToBucket(AddInvoicesRequest request)
        {
            var config = new Config();
            var response = new AddInvoicesResponse();
            var baseUrl = config.BucketBaseApiEndPointUrl();
            var addInvoicesEndPoint = config.AddInvoicesApiEndPointUrl();

            try
            {
                var restClient = new HttpRestClientActivity();
                response = restClient.RestActivity<AddInvoicesResponse>(baseUrl, addInvoicesEndPoint, Method.POST,request);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }

            return response;


        }


        public DeleteBucketResponse DeleteBucket(DeleteBucketRequest request)
        {
            var config = new Config();
            var response = new DeleteBucketResponse();
            var baseUrl = config.BucketBaseApiEndPointUrl();
            var deleteBucketEndPointUrl = config.DeleteBucketApiEndPointUrl();

            var parameters = new Dictionary<string, string>();
            parameters.Add("bucketId", request.BucketId.ToString());

            try
            {
                var restClient = new HttpRestClientActivity();
                response = restClient.RestActivity<DeleteBucketResponse>(baseUrl, deleteBucketEndPointUrl, Method.POST, request, null, parameters);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }

            return response;


        }


        public SubmitBucketResponse SubmitBucket(SubmitBucketRequest request)
        {
            var config = new Config();
            var response = new SubmitBucketResponse();
            var baseUrl = config.BucketBaseApiEndPointUrl();
            var deleteBucketEndPointUrl = config.SubmitBucketApiEndPointUrl();

            var parameters = new Dictionary<string, string>();
            parameters.Add("bucketId", request.BucketId.ToString());

            try
            {
                var restClient = new HttpRestClientActivity();
                response = restClient.RestActivity<SubmitBucketResponse>(baseUrl, deleteBucketEndPointUrl, Method.POST, request, null, parameters);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }

            return response;


        }


        public UpdateDateResponse UpdateDate(UpdateDateRequest request)
        {
            var config = new Config();
            var response = new UpdateDateResponse();
            var baseUrl = config.BucketBaseApiEndPointUrl();
            var updateBucketDateEndPoint = config.BucketUpdateDateEndPointUrl();

            var parameters = new Dictionary<string, string>();
            parameters.Add("bucketId", request.BucketId.ToString());
            parameters.Add("UpdateDate", request.UpdateDate.ToLongDateString());

            try
            {
                var restClient = new HttpRestClientActivity();
                response = restClient.RestActivity<UpdateDateResponse>(baseUrl, updateBucketDateEndPoint, Method.POST, request, null, parameters);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }

            return response;


        }




        public RemoveInvoicesResponse RemoveInvoicesToBucket(RemoveInvoicesRequest request)
        {
            var config = new Config();
            var response = new RemoveInvoicesResponse();
            var baseUrl = config.BucketBaseApiEndPointUrl();
            var removeInvoicesEndPoint = config.RemoveInvoicesApiEndPointUrl();

            try
            {
                var restClient = new HttpRestClientActivity();
                response = restClient.RestActivity<RemoveInvoicesResponse>(baseUrl, removeInvoicesEndPoint, Method.POST, request);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }

            return response;


        }


        public BucketDetailResponse GetBucketDetails(int bucketId)
        {
            var config = new Config();
            var response = new BucketDetailResponse();
            var baseUrl = config.BucketBaseApiEndPointUrl();
            var bucketDetailEndPoint = config.BucketDetailsApiEndPointUrl();
            var pathParameters = new Dictionary<string, string>();
            pathParameters.Add("bucketId", bucketId.ToString());
            try
            {
                var restClient = new HttpRestClientActivity();
                response = restClient.RestActivity<BucketDetailResponse>(baseUrl, bucketDetailEndPoint, Method.GET,null,postParam:pathParameters);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.ErrorMessage = e.Message;
            }

            return response;


        }
    }
}
