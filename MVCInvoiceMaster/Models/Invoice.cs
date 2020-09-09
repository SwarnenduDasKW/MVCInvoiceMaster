using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCInvoiceMaster.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [DisplayName("Invoice #")]
        public string InvoiceNumber { get; set; }

        [DisplayName("Customer ID #")]
        public int CustomerId { get; set; }

        [DisplayName("Country")]
        public string Country { get; set; }

        [DisplayName("State")]
        public string State { get; set; }

        [DisplayName("Tax")]
        public decimal AdvancePaymentTax { get; set; }

        [DisplayName("Due Date")]
        public DateTime DueDate { get; set; }
        public IEnumerable<InvoiceDetail> InvoiceDetails { get; set; }
    }
}