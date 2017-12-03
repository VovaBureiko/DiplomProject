using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication14.Domain.Concrete
{
    public class Current
    {
        public string Name { get; set; }
        public List<string> SPec = new List<string>();

        public void Add(string str)
        {
            SPec.Add(str);
        }
    }
}