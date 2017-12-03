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
        private ISpecializations sp;
        public StartTestController(IOsn osn, ISpecial spec, IDisciples disc, ISpecializations sp)
        {
            this.osn = osn;
            this.spec = spec;
            this.disc = disc;
            this.sp = sp;
        }
        
        public ActionResult StartingTest()
        {
            CreatSpisok();
            return View();
        }
        private void CreatSpisok()
        {
            ChooseDiscpl ch = (ChooseDiscpl)Session["Chose"];
            SpecConstructor cart = (SpecConstructor)Session["Cart"];
            NewSummary sm = (NewSummary)Session["Summary"];
    //        Cof cf = (Cof)Session["Cofec"];
            if(cart == null)
            {
                cart = new SpecConstructor();
                cart.add();
                Session["Cart"] = cart;
            }
            if(sm == null)
            {
                sm = new NewSummary();
                sm.AddSummary(sp);
                Session["Summary"] = sm;
            }
            if(ch == null)
            {
                ch = new ChooseDiscpl();
                
            }
            Stack<string> tel = new Stack<string>();
            string[] mas = new string[] { "Телекомунікаційні та інформаційні сеті", "Телекомунікаційні і інформаційні технології", "Цифрова обробка сигналів", "Мобільні та супутниковіє системи звязку", "Присторої Надвисоких частот", "Web - програмування", "Телекомунікаційні системи передач", "Електронні прилади" };
            for(int i = mas.Length-1;i<-1;i--)
            {
                tel.Push(mas[i]);
            }
            Session["Push"] = tel;
            //if(cf == null)
            //{
            //    cf = new Cof();
            //    cf.AddNapr(sp);
            //    Session["Cofec"] = cf;
            //}
        }

    }
}