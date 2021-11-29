using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Messages.Bucket.Responses
{
    public class BasketBaseResponse
    { 
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
