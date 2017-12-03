using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication14.Domain.Abstract;
using WebApplication14.Models.DataBaseModel;

namespace WebApplication14.Domain.Concrete
{
    public class Napravlenia : ISpecializations
    {
        MoDel md = new MoDel();
        public IQueryable<Specializations> spec
        {
            get
            {
                return md.Specializations;
            }
        }
    }
}