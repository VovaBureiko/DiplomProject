using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication14.Domain.Concrete;

namespace WebApplication14.Controllers
{
    public class EndTestController : Controller
    {
        public ActionResult EndTest()
        {
        //    NewSummary sm = ((NewSummary)Session["Summary"]);

        //    return PartialView("EndTest", new ViewEndTest { SummaryList = sm.FinalSum });
            return View();
        }
    }
}