using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication14.Domain.Abstract;
using WebApplication14.Models.DataBaseModel;

namespace WebApplication14.Domain.Concrete
{
    public class DisciplesDirectory : IDisciples
    {
        MoDel context = new MoDel();
        public IQueryable<Disciple> Disciples
        {
            get
            {
                return context.Disciple;
            }
        }
    }
}