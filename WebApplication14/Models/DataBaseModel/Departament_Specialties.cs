namespace WebApplication14.Models.DataBaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Departament_Specialties
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Departament_Specialties()
        {
            Specializations = new HashSet<Specializations>();
        }

        public int id { get; set; }

        public int id_departament { get; set; }

        public int id_specialties { get; set; }

        public virtual Departament Departament { get; set; }

        public virtual Specialties Specialties { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Specializations> Specializations { get; set; }
    }
}
