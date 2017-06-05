namespace WebApplication14.Models.DataBaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Osn_table
    {
        public int id { get; set; }

        public int id_disc { get; set; }

        public int id_spec { get; set; }

        public int ves { get; set; }

        public virtual Disciple Disciple { get; set; }

        public virtual Specializations Specializations { get; set; }
    }
}
