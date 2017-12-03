using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace WebApplication14.Domain.Concrete
{
    public class ChooseDiscpl
    {
        private List<Current> dicp = new List<Current>();

        public void Add(string name, string dics)
        {
           var a = dicp.Where(k => k.Name == name).Select(k => k.SPec).FirstOrDefault();
            a.Add(dics);
        }
        public void New(string name)
        {
            dicp.Add(new Current { Name = name, SPec = new List<string>() });
        }
        public IEnumerable<Current> RetrunSpicok { get { return dicp; } }
    }
}