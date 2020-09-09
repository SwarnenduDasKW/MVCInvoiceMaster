using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceDBPersistence.Models
{
    public class DBSale
    {
        public string SalesItem { get; set; }
        public DateTime DateSold { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string ShipToLoc { get; set; }
    }
}
