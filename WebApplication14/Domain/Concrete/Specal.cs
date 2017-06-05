using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication14.Models.DataBaseModel;
using WebApplication14.Domain.Abstract;
namespace WebApplication14.Domain.Concrete
{
    public class Specal : ISpecial
    {
        MoDel contex = new MoDel();
        public IEnumerable<Specialties> Spec
        {
            get
            {
                return contex.Specialties;
            }
        }
    }
}