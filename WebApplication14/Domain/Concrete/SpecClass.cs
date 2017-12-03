using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication14.Models.DataBaseModel;
using WebApplication14.Domain.Concrete;
using WebApplication14.Domain.Abstract;

namespace WebApplication14.Domain.Concrete
{
    public class SpecClass
    {
        public string Name { get; set; }

        public Stack<DispPlusVes> dic { get; set; }

        public double Porog { get; set; }

        public int Median { get; set; }
    }

    public class SpecConstructor
    {
        List<SpecClass> specalist = new List<SpecClass>();
        Stack<string> mystack = new Stack<string>();
        public void add()
        {
            MoDel md = new MoDel();
            var p = from spec in md.Specializations
                    join comp in md.Osn_table on spec.id equals comp.id_spec
                    join disc in md.Disciple on comp.id_disc equals disc.id_discipl
                    select new { Name = spec.name, Name_Disc = disc.nazvan, ves = comp.ves };
            var m = p.Select(k => k.Name).Distinct();
            var spicok = from a in m join b in p on a equals b.Name into lst select new { Name = a, Tlist = lst.Distinct().OrderBy(k => k.ves) };
            foreach (var name in spicok)
            {
                Stack<DispPlusVes> mydictionary = new Stack<DispPlusVes>();
                foreach (var name2 in name.Tlist)
                {
                    mydictionary.Push(new DispPlusVes { Name = name2.Name_Disc, ves = name2.ves});
                }
                var id = md.Specializations.Where(l => l.name == name.Name).Select(k => k.id).First();
                double porog = md.Osn_table.Where(k => k.id_spec == id).Sum(o => o.ves) / md.Osn_table.Where(z => z.id_spec == id).Count();
                porog /= 35;
                int[] masves = md.Osn_table.Where(k => k.id_spec == id).Select(q => q.ves).OrderBy(k => k).ToArray();
                int median = masves[Convert.ToInt32(Math.Floor((double)masves.Length / 2))];
                specalist.Add(new SpecClass { Name = name.Name, dic = mydictionary, Porog = porog, Median = median });
            }
        }
        public void Remove(string[] key, Dictionary<string, int> diss)
        {
            for (int i = 0; i < key.Count(); i++)
            {
                diss.Remove(key[i]);
            }
        }
        public IEnumerable<SpecClass> Lines
        {
            get { return specalist; }
        }
        public int Serch(string name)
        {
            var mas = specalist.Where(k => k.Name == name).Select(l => l.dic).Take(2);
            var num = mas.Select(l => l.Peek()).Select(l => l.ves).ToArray();
            int sum = num.Sum();
          
            return sum;

        }
        public int AnotherSum(string name)

        {
            var mas = specalist.Where(k => k.Name != name).Select(l => l.dic).Select(m => m.Take(2));
            var num = mas.Sum(k => k.Sum(w => w.ves));
            return num;
        }
        public List<string> ReturunNewPec()
        {
            List<string> spisok = new List<string>();
          foreach (var a in Lines)
            {
                    for (int i = 0; i < 2; i++)
                    {
                    try
                    {
                        spisok.Add(a.dic.Pop().Name);
                     //   spisok.Add(mystack.Pop());
                    }
                    catch
                    {
                        return null;
                    }
                }
                
               
            }
          
          
            return spisok;
        }
    }

    public class DispPlusVes
    {
       public string Name { get; set; }

       public int ves { get; set; }
    }
    }


