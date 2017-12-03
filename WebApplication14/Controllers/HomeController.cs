using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication14.Models.DataBaseModel;

namespace WebApplication14.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
           
            MoDel md = new MoDel();
            var photo = md.PhotoDirectory.Select(p => p.photo);
            List<string> name = new List<string>();
            foreach(string s in photo)
            {
                name.Add(s);
            }
            Session["Photo"] = name[0];
            return View(name);
        }
        public ActionResult Contact(int name)
        {
            return RedirectToAction("Index", "Test");
      }

    }
}