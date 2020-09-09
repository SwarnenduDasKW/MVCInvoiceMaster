using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVCInvoiceMaster.Models
{
    public class Customer
    {

        public int CustomerID { get; set; }

        [Required(ErrorMessage ="Name is mandatory")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Company Name is mandatory")]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Pin is mandatory")]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "City is required")]
        [DisplayName("City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Contact name is required")]
        [DisplayName("Contact Person Name")]
        public string ContactPerson { get; set; }

        [Required(ErrorMessage = "Telephone is required")]
        [DisplayName("Telephone")]
        public string Telephone { get; set; }

        [StringLength(10, ErrorMessage ="Mobile number cannot be more than 10 digits")]
        [DisplayName("Mobile")]
        public string Mobile { get; set; }

        [DisplayName("Fax")]
        public string Fax { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DisplayName("Email")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Wrong email format")]
        public string Email { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }   

    }
}