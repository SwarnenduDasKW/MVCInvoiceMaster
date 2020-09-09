using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCInvoiceMaster.Models;
using PagedList;

namespace MVCInvoiceMaster.Controllers
{
    public class CustomersController : Controller
    {
        private MVCInvoiceMasterContext db = new MVCInvoiceMasterContext();

        // GET: Customers
        //public ActionResult Index()
        //{

        //    var customers = from c in db.Customers
        //                    select c;

        //    //return View(db.Customers.ToList());
        //    return View(customers.ToList());
        //}

        public ViewResult Index(int? page, string currentFilter, string searchString, string searchBy)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            

            ViewBag.SearchBy = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem { Text = "Name", Value = "1"},
                    new SelectListItem { Text = "Company Name", Value = "2"},
                    new SelectListItem { Text = "City", Value = "3"},
                    new SelectListItem { Text = "Mobile", Value = "4"},
                    new SelectListItem { Text = "Email", Value = "5"}
                }, "Value", "Text");

            
            var customers = from c in db.Customers
                            select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                switch (searchBy)
                {
                    case "1":
                        customers = customers.Where(c => c.Name.Contains(searchString));
                        break;
                    case "2":
                        customers = customers.Where(c => c.CompanyName.Contains(searchString));
                        break;
                    case "3":
                        customers = customers.Where(c => c.City.Contains(searchString));
                        break;
                    case "4":
                        customers = customers.Where(c => c.Mobile.Contains(searchString));
                        break;
                    case "5":
                        customers = customers.Where(c => c.Email.Contains(searchString));
                        break;
                    default:
                        break;
                }
            }

            customers = customers.OrderBy(s => s.CustomerID);

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(customers.ToPagedList(pageNumber, pageSize));
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,Name,CompanyName,Address,ZipCode,City,ContactPerson,Telephone,Mobile,Fax,Email,Notes")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,Name,CompanyName,Address,ZipCode,City,ContactPerson,Telephone,Mobile,Fax,Email,Notes")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
