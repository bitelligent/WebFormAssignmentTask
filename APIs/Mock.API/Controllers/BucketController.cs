using Application.Common.Messages.Bucket.Requests;
using Application.Common.Messages.Bucket.Responses;
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

        public BucketController(IBucketService bucketService)
        {
            _bucketService = bucketService;
        }

        [HttpPost]
        [Route("approve")]
        [ProducesResponseType(typeof(SubmitBucketResponse), (int)HttpStatusCode.OK)]
        public ActionResult<SubmitBucketResponse> Approve([FromBody] SubmitBucketRequest request)
        {
            var response = _bucketService.SubmitBucket(request);
            return Ok(response);
        }



    }
}
