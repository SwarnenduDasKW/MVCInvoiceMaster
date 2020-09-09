using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using InvoiceDBPersistence;
using InvoiceDBPersistence.Models;
using MVCInvoiceMaster.Models;

namespace MVCInvoiceMaster.Controllers
{
    
    public class SaleController : BaseController
    {

        private MVCInvoiceMasterContext db = new MVCInvoiceMasterContext();
        private readonly string connString = ConfigurationManager.ConnectionStrings["MVCInvoiceMasterContext"].ConnectionString;
        
        // GET: Sale
        public ActionResult Index()
        {
            return View(db.Sales.ToList());
        }

        // GET: Sale/Details/5
        public ActionResult Details(int id)
        {
            Sale sale = db.Sales.Find(id);
            return View(sale);
        }

        // GET: Sale/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sale/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                DBSale sale = new DBSale();
                sale.SalesItem = collection["SalesItem"];
                sale.DateSold = Convert.ToDateTime(collection["DateSold"]);
                sale.Quantity = Convert.ToInt32(collection["Quantity"]);
                sale.Price = Convert.ToDouble(collection["Price"]);
                sale.ShipToLoc = collection["ShipToLoc"];

                SQLPersistor sp = new SQLPersistor(connString);

                sp.AddSales(sale);

                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }
        }

        // GET: Sale/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sale/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sale/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sale/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
