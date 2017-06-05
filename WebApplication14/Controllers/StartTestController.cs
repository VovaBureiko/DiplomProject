using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication14.Domain.Abstract;
using WebApplication14.Domain.Concrete;
using WebApplication14.Models;
namespace WebApplication14.Controllers
{
    public class StartTestController : Controller
    {
        private IOsn osn;
        private ISpecial spec;
        private IDisciples disc;
        public StartTestController(IOsn osn, ISpecial spec, IDisciples disc)
        {
            this.osn = osn;
            this.spec = spec;
            this.disc = disc;
        }
        
        public ActionResult StartingTest()
        {
            CreatSpisok();
            return View();
        }
        private SpecConstructor CreatSpisok()
        {
            SpecConstructor cart = (SpecConstructor)Session["Cart"];
            if(cart == null)
            {
                cart = new SpecConstructor();
                cart.add();
                Session["Cart"] = cart;
            }

            return cart;
        }

    }
}