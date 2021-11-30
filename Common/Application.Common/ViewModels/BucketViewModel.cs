using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.ViewModels
{
    public class BucketViewModel
    {
        public BucketViewModel()
        {
            Invoices = new List<InvoiceViewModel>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public int BuyerComComId { get; set; }

        public int SupplierComComId { get; set; }

        public string FinanceMethod { get; set; }


        public bool IsDuedate { get; set; }


        public DateTime FutureFinanceDate { get; set; }

        public int Status { get; set; }

        public DateTime DateInserted { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<InvoiceViewModel> Invoices { get; set; }

        public bool IsDeleted { get; set; }
    }
}
