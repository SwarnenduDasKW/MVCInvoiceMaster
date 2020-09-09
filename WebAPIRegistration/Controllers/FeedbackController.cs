using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIRegistration.Models;

namespace WebAPIRegistration.Controllers
{
    public class FeedbackController : ApiController
    {
        [Authorize]
        public IEnumerable<ContactUs> Get()
        { 
            InvoiceMasterEntities db = new InvoiceMasterEntities();
            return db.ContactUs1.ToList();
        }


    }
}
