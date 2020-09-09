using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCInvoiceMaster.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View();
        }
        public ViewResult AwSnap(int id)
        {
            Response.StatusCode = id;  

            return View();
        }

    }
}