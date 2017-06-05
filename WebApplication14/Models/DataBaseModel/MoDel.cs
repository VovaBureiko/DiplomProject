namespace WebApplication14.Models.DataBaseModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MoDel : DbContext
    {
        public MoDel()
            : base("name=Diplom")
        {
        }

        public virtual DbSet<Departament> Departament { get; set; }
        public virtual DbSet<Departament_Specialties> Departament_Specialties { get; set; }
        public virtual DbSet<Disciple> Disciple { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<Osn_table> Osn_table { get; set; }
        public virtual DbSet<Specializations> Specializations { get; set; }
        public virtual DbSet<Specialties> Specialties { get; set; }
        public virtual DbSet<PhotoDirectory> PhotoDirectory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departament>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Departament>()
                .HasMany(e => e.Departament_Specialties)
                .WithRequired(e => e.Departament)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Departament_Specialties>()
                .HasMany(e => e.Specializations)
                .WithOptional(e => e.Departament_Specialties)
                .HasForeignKey(e => e.id_dep_spec);

            modelBuilder.Entity<Disciple>()
                .Property(e => e.nazvan)
                .IsUnicode(false);

            modelBuilder.Entity<Disciple>()
                .HasMany(e => e.Osn_table)
                .WithRequired(e => e.Disciple)
                .HasForeignKey(e => e.id_disc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Faculty>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Faculty>()
                .HasMany(e => e.Departament)
                .WithRequired(e => e.Faculty)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Specializations>()
                .Property(e => e.num_specializations)
                .HasPrecision(9, 8);

            modelBuilder.Entity<Specializations>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Specializations>()
                .HasMany(e => e.Osn_table)
                .WithRequired(e => e.Specializations)
                .HasForeignKey(e => e.id_spec)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Specialties>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Specialties>()
                .HasMany(e => e.Departament_Specialties)
                .WithRequired(e => e.Specialties)
                .HasForeignKey(e => e.id_specialties)
                .WillCascadeOnDelete(false);
        }
    }
}
