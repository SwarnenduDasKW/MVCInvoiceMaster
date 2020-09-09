using System;
using System.Web.Mvc;
using System.Configuration;
using System.Linq;
using InvoiceDBPersistence;
using InvoiceDBPersistence.Models;
using System.Collections.Generic;
using MVCInvoiceMaster.Models;
using System.Globalization;
using System.Data.Sql;
using System.Data;

namespace MVCInvoiceMaster.Controllers
{
    public class InvoiceController : BaseController
    {
        private readonly string connString = ConfigurationManager.ConnectionStrings["MVCInvoiceMasterContext"].ConnectionString;
        private MVCInvoiceMasterContext db = new MVCInvoiceMasterContext();
       
        // GET: Invoice
        public ActionResult List()
        {
            var invoice = db.Invoices;

            return View(invoice.ToList());
        }

        public ActionResult InvoiceDetail(int id)
        {
            var invoiceDetails = db.InvoiceDetails.Where(x => x.InvoiceId == id);

            return View(invoiceDetails.ToList());
        }

        [HttpPost]
        public ActionResult CreateInvoice(string invoiceno,int customerid, string country, string state, decimal advpymttax, DateTime duedate)
        {
            // invoiceno: s_invoiceno, customerid: s_customerid, country: s_country, state: s_state, advpymttax: s_advpymttax, duedate: s_duedate
            DBInvoice dbi = new DBInvoice()
                            {
                                InvoiceNumber = invoiceno,
                                CustomerId = customerid,
                                Country = country,
                                State = state,
                                AdvancePaymentTax = advpymttax,
                                DueDate = duedate
                            };

            SQLPersistor p = new SQLPersistor(connString);
            p.InsertInvoice(dbi);

            List<Invoice> invoiceList = new List<Invoice>();
            DataTable dt = new DataTable();

            dt = p.GetInvoiceList();
            invoiceList = (from DataRow row in dt.Rows
                           select new Invoice()
                           {
                               InvoiceId = Convert.ToInt32(row["InvoiceId"].ToString()),
                               InvoiceNumber = row["InvoiceNumber"].ToString(),
                               CustomerId = Convert.ToInt32(row["CustomerID"]),
                               Country = row["Country"].ToString(),
                               State = row["State"].ToString(),
                               AdvancePaymentTax = Convert.ToDecimal(row["AdvancePaymentTax"]),
                               DueDate = Convert.ToDateTime(row["DueDate"])
                           }).ToList();

            return View(invoiceList);
            //RedirectToAction("MasterDetail", "Invoice");
        }

        public JsonResult GetCountry()
        {
            List<Country> countryList = new List<Country>();
            SQLPersistor p = new SQLPersistor(connString);

            countryList = p.GetCountry();

            return Json( countryList.Select(x => new {
                                            CountryCode = x.CountryCode,
                                            CountryName = x.CountryName
                            }).ToList(),JsonRequestBehavior.AllowGet);
                
        }

        public JsonResult GetState(string CountryCode)
        {
            List<State> stateList = new List<State>();
            SQLPersistor p = new SQLPersistor(connString);

            stateList = p.GetState(CountryCode);

            return Json(stateList.Select(x => new {
                StateCode = x.StateCode,
                StateName = x.StateName
            }).ToList(), JsonRequestBehavior.AllowGet);

        }

       public ActionResult MasterDetail()
       {
            List<Invoice> invoiceList = new List<Invoice>();
            
            SQLPersistor p = new SQLPersistor(connString);
            DataTable dt = new DataTable();

            dt = p.GetInvoiceList();

            invoiceList = (from DataRow row in dt.Rows
                           select new Invoice()
                           {
                               InvoiceId = Convert.ToInt32(row["InvoiceId"].ToString()),
                               InvoiceNumber = row["InvoiceNumber"].ToString(),
                               CustomerId = Convert.ToInt32(row["CustomerID"]),
                               Country = row["Country"].ToString(),
                               State = row["State"].ToString(),
                               AdvancePaymentTax = Convert.ToDecimal(row["AdvancePaymentTax"]),
                               DueDate = Convert.ToDateTime(row["DueDate"])
                           }).ToList();

            /*
            foreach (var x in invoiceList)
            {
                dt = p.getInvoiceDetails(x.InvoiceId);
                x.InvoiceDetails = (from DataRow row in dt.Rows
                                    select new InvoiceDetail()
                                    {
                                        InvoiceId = Convert.ToInt32(row["InvoiceId"].ToString()),
                                        Description = row["Description"].ToString(),
                                        Quantity = Convert.ToInt32(row["Quantity"].ToString()),
                                        Price = Convert.ToDecimal(row["Price"].ToString()),
                                        Vat = Convert.ToDecimal(row["Vat"]),
                                    }).ToList();

            }
            */
            return View(invoiceList);
        }

        public PartialViewResult InvoiceDetailPartial(int id)
        {
            List<InvoiceDetail> detailList = new List<InvoiceDetail>();

            SQLPersistor p = new SQLPersistor(connString);
            DataTable dt = p.getInvoiceDetails(id);

            detailList = (from DataRow row in dt.Rows
                           select new InvoiceDetail()
                           {
                               InvoiceId = Convert.ToInt32(row["InvoiceId"].ToString()),
                               Description = row["Description"].ToString(),
                               Quantity = Convert.ToInt32(row["Quantity"].ToString()),
                               Price = Convert.ToDecimal(row["Price"].ToString()),
                               Vat = Convert.ToDecimal(row["Vat"].ToString()),
                               Memo = row["Memo"].ToString()
                           }).ToList();



            return PartialView("_InvoiceDetailPartial", detailList);
        }

    }
}