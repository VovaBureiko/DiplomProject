﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication14.Models.DataBaseModel;
using WebApplication14.Domain.Abstract;

namespace WebApplication14.Domain.Concrete
{
    public class Osnova : IOsn
    {
        MoDel contex = new MoDel();
        public IQueryable<Osn_table> Osn
        {
            get
            {
                return contex.Osn_table;
            }
        }
    }
}