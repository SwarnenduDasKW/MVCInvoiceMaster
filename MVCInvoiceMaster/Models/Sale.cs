namespace MVCInvoiceMaster.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sale
    {
        [Key]
        public int SalesId { get; set; }

        [StringLength(50)]
        [DisplayName("Sales Item")]
        public string SalesItem { get; set; }

        [DisplayName("Sale Date")]
        public DateTime? DateSold { get; set; }

        [DisplayName("No. of Items")]
        public int? Quantity { get; set; }

        [DisplayName("Price")]
        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [DisplayName("Shipping Destination")]
        [StringLength(50)]
        public string ShipToLoc { get; set; }
    }
}
