using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication14.Models.DataBaseModel;
using WebApplication14.Domain.Abstract;

namespace WebApplication14.Domain.Concrete
{
    public class SpecClass
    {
         public string Name { get; set; }

         public Stack<DispPlusVes> dic { get; set; }

    }

    public class SpecConstructor
    {
        List<SpecClass> specalist = new List<SpecClass>();
        public void add()
        {
            MoDel md = new MoDel();
            var p = from spec in md.Specializations
                    join comp in md.Osn_table on spec.id equals comp.id_spec
                    join disc in md.Disciple on comp.id_disc equals disc.id_discipl 
                    select new { Name = spec.name,Name_Disc = disc.nazvan, ves = comp.ves };
            var m = p.Select(k => k.Name).Distinct();
            var spicok = from a in m join b in p on a equals b.Name into lst select new { Name = a, Tlist = lst.Distinct().OrderBy(k => k.ves)};
            foreach (var name in spicok)
            {
                Stack<DispPlusVes> mydictionary = new Stack<DispPlusVes>();
                foreach (var name2 in name.Tlist)
                {
                    mydictionary.Push(new DispPlusVes { Name = name2.Name_Disc, ves = name2.ves, isSelected = false });
                }
                specalist.Add(new SpecClass { Name = name.Name, dic=mydictionary });
            }
            int l = 0;
        }
        public void Remove(string[] key, Dictionary<string, int> diss)
        {
            for(int i = 0; i<key.Count();i++)
            {
                diss.Remove(key[i]);
            }
        }
        public IEnumerable<SpecClass> Lines
        {
            get { return specalist ; }
        }
    }
    public class DispPlusVes
    {
       public string Name { get; set; }

       public int ves { get; set; }

       public bool isSelected { get; set; }
    }
    }


