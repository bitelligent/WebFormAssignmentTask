using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.ViewModels;

namespace Application.Common.Messages.Bucket.Requests
{
    public class BucketBaseRequest
    {
        public int BucketId { get; set; }
        public List<BucketViewModel> BucketViewModels { get; set; }

        public List<InvoiceViewModel> InvoiceViewModels { get; set; }

    }
}
