using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDBPersistence.Models
{
    public class DBInvoice
    {
        public string InvoiceNumber { get; set; }

        public int CustomerId { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public decimal AdvancePaymentTax { get; set; }

        public DateTime DueDate { get; set; }
    }
}
