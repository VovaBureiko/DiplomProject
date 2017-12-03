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
        private ISpecializations spec;
        private IDisciples disc;

        public TestController(IOsn osn, ISpecializations spec, IDisciples disc)
        {
            this.osn = osn;
            this.spec = spec;
            this.disc = disc;
        }
        [HttpGet]
        public PartialViewResult FirstSpisok(List<string> spisok)
        {
            {
                if (spisok != null)
                {
                    return PartialView(new ViewCurrentDisciples { sp = spisok });
                }
                Stack<string> str = (Stack<string>)Session["Push"];
                return PartialView(new ViewCurrentDisciples { sp = ((SpecConstructor)Session["Cart"]).ReturunNewPec() });
            }
        }
        [HttpPost]
        public ActionResult FirstSpisok(ModelOfOutPut mf)
        {
           NewSummary sm = Sum(mf);
            Stack<string> str = (Stack<string>)Session["Push"];
            List<string> currnetdisp = ((SpecConstructor)Session["Cart"]).ReturunNewPec();
            if(currnetdisp==null)
            {
                return RedirectToAction("EndTest", "EndTest");
            }
           return PartialView(new ViewCurrentDisciples { sp = currnetdisp});
        }
        private NewSummary Sum(ModelOfOutPut mf)
        {
            NewSummary sm = (NewSummary)Session["Summary"];
            char[] trim = { ' ', '\n', '\t'};
            for (int i = 0; i < mf.Params.Length; i++)
            {
                string str = mf.Params[i];
                str = str.Trim(trim);
                if (str == null) { str = mf.Params[i + 1]; i++; str = str.Trim(trim); }
                var result = disc.Disciples.Where(l => l.nazvan == str).Select(m => m.id_discipl).First();
                var naprav = osn.Osn.Where(l => l.id_disc == result).Select(m => m.id_spec).FirstOrDefault();
                var special = spec.spec.Where(l => l.id == naprav).Select(m => m.name).FirstOrDefault();
                if (!mf.Check[i])
                {
                    double sum = sm.FinalSum.Where(l => l.NameOfSpec == special).Select(k => k.Sum).First();
                    int ves = osn.Osn.Where(n => n.id_disc == result).Select(h => h.ves).FirstOrDefault();
                    var delete = sm.FinalSum.Where(l => l.NameOfSpec == special).Select(k => k).FirstOrDefault();
                    sum -= ves;
                    sm.RemoveLine(delete);
                    sm.AddLine(special, sum);
                }
                else
                {

                    double ves = osn.Osn.Where(h => h.id_disc == result).Select(y => y.ves).FirstOrDefault();
                    sm.ChengeLine(ves, special);
                }             
            }
            Session["Summary"] = sm;
       //     Session["Cofec"] = cof;
            return sm;
        }
    }
}