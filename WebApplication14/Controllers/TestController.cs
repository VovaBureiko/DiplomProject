using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication14.Models.DataBaseModel;
using WebApplication14.Domain.Concrete;
using WebApplication14.Domain.Abstract;
namespace WebApplication14.Controllers
{
    public class TestController : Controller
    {
        private IOsn osn;
        private ISpecial spec;
        private IDisciples disc;
        public TestController(IOsn osn, ISpecial spec, IDisciples disc)
        {
            this.osn = osn;
            this.spec = spec;
            this.disc = disc;
        }
        public PartialViewResult FirstSpisok()
        {
            return PartialView(new ViewCurrentDisciples { sp = (SpecConstructor)Session["Cart"] });
        }

        [HttpPost]
        public PartialViewResult FirstSpisok(ModelOfOutPut mf)
        {
            
                return PartialView(new ViewCurrentDisciples { sp = (SpecConstructor)Session["Cart"] });
            
        }
    }
}