using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication14.Domain.Abstract;

namespace WebApplication14.Domain.Concrete
{
    public class CofNapr
    {
        public string NameOfSpec { get; set; }
        public double Coof { get; set; }
    }
    public class Cof
    {
        private List<CofNapr> correctnapr = new List<CofNapr>();

        public void AddNapr(ISpecializations spec)
        {
            var specializ = spec.spec.Select(k => k.name);
            foreach(string s in specializ)
            {
                correctnapr.Add(new CofNapr { NameOfSpec = s, Coof = 0 });
            }
            

        }
        public void ChengeLine(double a, string Name)
        {
           CofNapr r = correctnapr.Where(u => u.NameOfSpec == Name).Select(o=>o).FirstOrDefault();
            r.Coof += a;
            
        }
        public void Normorov()
        {
            foreach(var a in correctnapr)
            {
                a.Coof /= 35;
            }
        }
        public IEnumerable<CofNapr> RetrunCof
        {
            get { return correctnapr; }
        }

    }
}