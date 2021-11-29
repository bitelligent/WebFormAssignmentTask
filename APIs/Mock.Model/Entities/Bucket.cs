using System;
using System.Collections.Generic;

namespace Mock.Model.Entities
{
   public class Bucket
    {
        public Bucket()
        {
            SupplierInvoices = new List<SupplierInvoice>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public int BuyerComComId { get; set; }

        public int SupplierComComId { get; set; }

        public string FinanceMethod { get; set; }


        public bool IsDuedate { get; set; }


        public  DateTime FutureFinanceDate { get; set; }

        public int Status { get; set; }

        public DateTime DateInserted { get; set; }

        public DateTime DateUpdated { get; set; }

        public List<SupplierInvoice> SupplierInvoices { get; set; }
        
        public bool IsDeleted { get; set; }




    }
}
