namespace WebApplication14.Models.DataBaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Disciple")]
    public partial class Disciple
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Disciple()
        {
            Osn_table = new HashSet<Osn_table>();
        }

        [Key]
        public int id_discipl { get; set; }

        [Required]
        [StringLength(100)]
        public string nazvan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Osn_table> Osn_table { get; set; }
    }
}
