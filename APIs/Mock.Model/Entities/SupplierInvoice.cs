using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mock.Model.Entities
{
    public class SupplierInvoice
    {
        public int Id { get; set; }
       
        public string DocReference { set; get; }

        public DateTime InvoiceDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string CreditReference { get; set; }

        public DateTime DueDate { get; set; }

        public  string CreditDebitFlag { get; set; }



    }
}
