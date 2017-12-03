using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication14.Models.DataBaseModel;

namespace WebApplication14.Domain.Abstract
{
   public interface ISpecializations
    {
        IQueryable<Specializations> spec { get;}
    }
}
