using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.ConfigSettings;

namespace Application.Common.ViewModels
{
    public class BucketViewModel
    {
        public BucketViewModel()
        {
            SupplierInvoices = new List<InvoiceViewModel>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public int BuyerComComId { get; set; }

        public int SupplierComComId { get; set; }

        public string FinanceMethod { get; set; }


        public bool IsDuedate { get; set; }


        public DateTime FutureFinanceDate { get; set; }

        public int Status { get; set; }

        public bool IsEditingAllowed()
        {
            return Status == 0;
        }

        public string GetStatus()
        {
            if (IsEditingAllowed())
                return "pencil";
            else return "gravel";


        }

        public string GetIcon()
        {
            var config = new Config();

            if (IsEditingAllowed())
                return config.PencilIconGifUrl();
            else return config.GavelIconGifUrl();
        }

        public DateTime DateInserted { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<InvoiceViewModel> SupplierInvoices { get; set; }

        public bool IsDeleted { get; set; }

        public string GetEditingUrl()
        {
            var config = new Config();


            if (IsEditingAllowed())
                return config.BucketDetailPageUrl() + Id;
            else return "#";
        }
    }
}
