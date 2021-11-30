using Application.Common.Messages.Bucket.Requests;
using Application.Common.Messages.Bucket.Responses;
using Application.Common.Messages.Invoice.Request;
using Application.Common.Messages.Invoice.Response;
using Application.Common.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mock.Model.Entities;
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

        public BucketController(IBucketService bucketService, IInvoiceService invoiceService, IMapper mapper)
        {
            _bucketService = bucketService;
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("approve")]
        public ActionResult<SubmitBucketResponse> Approve([FromBody] SubmitBucketRequest request)
        {
            var response = _bucketService.SubmitBucket(request);
            if (response.Success)
                return Accepted(response);
            else return BadRequest(response.ErrorMessage);

        }

        [HttpGet]
        [Route("bucketDetails")]
        public ActionResult<BucketDetailResponse> BucketDetails(int bucketId)
        {
            var request = new BucketDetailRequest() {BucketId = bucketId};
            var bucket = _bucketService.GetBucket(request);
            var response = new BucketDetailResponse
                {Success = true,
                    Bucket = _mapper.Map<BucketViewModel>(bucket)};
            return Ok(response);
        }

        [HttpGet]
        [Route("buckets")]
        public ActionResult<BucketListResponse> Buckets()
        {
            var request = new BucketListRequest();
            var buckets = _bucketService.GetBucketList(request);
            var response = new BucketListResponse
            {
                Success = true, Buckets = _mapper.Map<List<BucketViewModel>>(buckets)
            };


            return Ok(response);
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult<DeleteBucketResponse> Delete([FromBody] DeleteBucketRequest request)
        {
            var response = _bucketService.DeleteBucket(request);
            if (response.Success)
                return Ok(response);
            else return BadRequest(response.ErrorMessage);
        }


        [HttpGet]
        [Route("pendingInvoices")]
        public ActionResult<PendingInvoiceListResponse> PendingInvoices()
        {
            var request = new PendingInvoiceListRequest();
            var invoices = _invoiceService.PendingInvoices(request);
            var response = new PendingInvoiceListResponse();
            response.Success = true;
            response.PendingInvoices = _mapper.Map<List<InvoiceViewModel>>(invoices);



            return Ok(response);
        }

        [HttpPost]
        [Route("relate")]
        public ActionResult<AddInvoicesResponse> Relate([FromBody] AddInvoicesRequest request)
        {
            var response = _bucketService.AddInvoices(request);
            if (response.Success)
                return Accepted(response);
            else return BadRequest(response.ErrorMessage);
        }

        [HttpPost]
        [Route("unrelate")]
        public ActionResult<RemoveInvoicesResponse> UnRelate([FromBody] RemoveInvoicesRequest request)
        {
            var response = _bucketService.RemoveInvoices(request);
            if (response.Success)
                return Accepted(response);
            else return BadRequest(response.ErrorMessage);

        }

        [HttpPost]
        [Route("updatedate")]
        public ActionResult<UpdateDateResponse> UpdateDate([FromBody] UpdateDateRequest request)
        {
            var response = _bucketService.UpdateDate(request);
            if (response.Success)
                return Accepted(response);
            else return BadRequest(response.ErrorMessage);

        }
    }
}