using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication14.Domain.Abstract;

namespace WebApplication14.Domain.Concrete
{
    public class SummaryClass
    {
        public string NameOfSpec { get; set; }
        public double Sum { get; set; }

        public double Normerovka { get; set; }
    }


    public class NewSummary
    {
        private List<SummaryClass> line = new List<SummaryClass>();

        public void AddSummary(ISpecializations spec)
        {
            var p = spec.spec.Select(l => l.name);
            foreach (var m in p)
            {
                line.Add(new SummaryClass { NameOfSpec = m, Sum = 35, Normerovka=0 });
            }
        }
        public void ChengeLine(double a, string Name)
        {
            SummaryClass r = line.Where(u => u.NameOfSpec == Name).Select(o => o).FirstOrDefault();
            r.Normerovka += a;

        }
        public void Normorov()
        {
            foreach (var a in line)
            {
                a.Normerovka /= 35;
            }
        }
        public IEnumerable<SummaryClass> FinalSum
        {
            get { return line; }
        }
        public void RemoveLine(SummaryClass sm)
        {
            line.Remove(sm);
        }
        public void AddLine(string name, double sum)
        {
            line.Add(new SummaryClass { NameOfSpec = name, Sum = sum });
        }

    }
}