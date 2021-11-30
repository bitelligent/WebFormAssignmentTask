using Application.Common.Messages.Bucket.Requests;
using Application.Common.Messages.Bucket.Responses;
using Application.Common.Messages.Invoice.Request;
using Application.Common.Messages.Invoice.Response;
using Application.Common.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mock.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Mock.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BucketController : ControllerBase
    {
        private readonly IBucketService _bucketService;
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public BucketController(IBucketService bucketService,IInvoiceService invoiceService , IMapper mapper)
        {
            _bucketService = bucketService;
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("approve")]
        [ProducesResponseType(typeof(SubmitBucketResponse), (int)HttpStatusCode.OK)]
        public ActionResult<SubmitBucketResponse> Approve([FromBody] SubmitBucketRequest request)
        {
            var response = _bucketService.SubmitBucket(request);
            return Ok(response);
        }

        [Route("bucketDetails")]
        [ProducesResponseType(typeof(BucketDetailResponse), (int)HttpStatusCode.OK)]
        public ActionResult<BucketDetailResponse> BucketDetails([FromBody] BucketDetailRequest request)
        {
            var bucket = _bucketService.GetBucket(request);
            var response = new BucketDetailResponse();
            response.Success = true;
            response.Bucket = _mapper.Map<BucketViewModel>(bucket);
            return Ok(response);
        }

        [Route("buckets")]
        [ProducesResponseType(typeof(BucketListResponse), (int)HttpStatusCode.OK)]
        public ActionResult<BucketListResponse> BucketDetails([FromBody] BucketListRequest request)
        {
            var buckets = _bucketService.GetBucketList(request);
            var response = new BucketListResponse();
            response.Success = true;
            response.Buckets = _mapper.Map<List<BucketViewModel>>(buckets);


            return Ok(response);
        }

        [HttpPost]
        [Route("delete")]
        [ProducesResponseType(typeof(DeleteBucketResponse), (int)HttpStatusCode.OK)]
        public ActionResult<DeleteBucketResponse> BucketDetails([FromBody] DeleteBucketRequest request)
        {
            var response = _bucketService.DeleteBucket(request);
            if (response.Success)
                return Ok(response);
            else return BadRequest(response.ErrorMessage);
        }


        
        [Route("pendingInvoices")]
        [ProducesResponseType(typeof(PendingInvoiceListResponse), (int)HttpStatusCode.OK)]
        public ActionResult<PendingInvoiceListResponse> PendingInvoices()
        {
            var request = new PendingInvoiceListRequest();
            var invoices = _invoiceService.PendingInvoices(request);
            var response = new PendingInvoiceListResponse();
            



            return Ok(response);
        }

    }
}
