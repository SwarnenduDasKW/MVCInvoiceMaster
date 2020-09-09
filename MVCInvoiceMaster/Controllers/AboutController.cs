using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InvoiceDBPersistence.Models;
using InvoiceDBPersistence;
using System.Configuration;

namespace MVCInvoiceMaster.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Feedback(string name,string email,string phone, string feedback)
        {
            string conStr = ConfigurationManager.ConnectionStrings["MVCInvoiceMasterContext"].ConnectionString;

            SQLPersistor p = new SQLPersistor(conStr);

            Feedback fb = new Feedback();
            fb.Name = name;
            fb.Email = email;
            fb.Phone = phone;
            fb.FeedbackComments = feedback;

            p.AddFeedback(fb);

            return View();
        }
    }
}