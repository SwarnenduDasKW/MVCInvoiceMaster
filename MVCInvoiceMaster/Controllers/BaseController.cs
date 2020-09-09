using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCInvoiceMaster.Controllers
{
    public class BaseController : Controller
    {

        protected override void OnException(ExceptionContext filterContext)
        {
            if(filterContext.ExceptionHandled)
                return;

            // Redirect on error:
            filterContext.Result = RedirectToAction("Index", "Error");

            // OR set the result without redirection:
            //filterContext.Result = new ViewResult
            //{
            //    ViewName = "~/Views/Shared/Error.cshtml"
            //};
        }
    }
}