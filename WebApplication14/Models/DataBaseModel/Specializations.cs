namespace WebApplication14.Models.DataBaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Specializations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Specializations()
        {
            Osn_table = new HashSet<Osn_table>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public decimal? num_specializations { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public int? id_dep_spec { get; set; }

        public virtual Departament_Specialties Departament_Specialties { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Osn_table> Osn_table { get; set; }
    }
}
