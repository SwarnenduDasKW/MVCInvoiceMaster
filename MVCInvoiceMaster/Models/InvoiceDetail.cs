using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCInvoiceMaster.Models
{
    public class InvoiceDetail
    {
        [Key]
        public int InvoiceDetailsId { get; set; }

        [DisplayName("Invoice Id")]
        public int InvoiceId { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Vat { get; set; }
        public string Memo { get; set; }
    }
}