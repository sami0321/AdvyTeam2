namespace PI4GL2.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using PI4GL2.Domain;
    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
            : base("MyDBContext")
        {
        }

        public virtual DbSet<conge> conges { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<formation> formations { get; set; }
        public virtual DbSet<manager> managers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<employee>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.conges)
                .WithOptional(e => e.employee)
                .HasForeignKey(e => e.employe_id);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.formations)
                .WithOptional(e => e.employee)
                .HasForeignKey(e => e.employee_id);

            modelBuilder.Entity<formation>()
                .Property(e => e.etablissement)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.skill)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<manager>()
                .HasMany(e => e.employees)
                .WithOptional(e => e.manager)
                .HasForeignKey(e => e.manager_id);
        }
    }
}
