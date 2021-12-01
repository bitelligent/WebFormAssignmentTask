using System;
using System.Collections.Generic;
using Application.Common.ConfigSettings;
using Application.Common.Messages.Bucket.Responses;
using Application.Common.Messages.Invoice.Response;
using RestSharp;
using WebForms.Services.Common;

namespace WebForms.Services.Invoice
{
    public class InvoiceHttpClientService : IInvoiceHttpClientService
    {

       

        public  PendingInvoiceListResponse GetPendingInvoices()
        {
            var config = new Config();
            var response = new PendingInvoiceListResponse();
            var baseUrl = config.BucketBaseApiEndPointUrl();
            var pendingInvoicesListEndPoint = config.PendingInvoicesEndPointUrl();
            try
            {
                var restClient = new HttpRestClientActivity();
                response =  restClient.RestActivity<PendingInvoiceListResponse>(baseUrl, pendingInvoicesListEndPoint, Method.GET);
                response.Success = true;
            }
            catch (Exception e)
            {
                response.ErrorMessage = e.Message;
            }

            return response;


        }


    
    }
}
