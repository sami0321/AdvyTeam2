namespace Domaine
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class hr : DbContext
    {
        public hr()
            : base("name=hr")
        {
        }

        public virtual DbSet<employee> employee { get; set; }
        public virtual DbSet<project> project { get; set; }
        public virtual DbSet<tasks> tasks { get; set; }
        public virtual DbSet<timesheet> timesheet { get; set; }
        public virtual DbSet<Forum> Forums{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<employee>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.timesheet)
                .WithOptional(e => e.employee)
                .HasForeignKey(e => e.employee_id);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.tasks)
                .WithOptional(e => e.employee)
                .HasForeignKey(e => e.employee_id);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.project)
                .WithOptional(e => e.employee)
                .HasForeignKey(e => e.Manager_id);

            modelBuilder.Entity<project>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .HasMany(e => e.tasks)
                .WithOptional(e => e.project)
                .HasForeignKey(e => e.project_id);

            modelBuilder.Entity<tasks>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<tasks>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<timesheet>()
                .HasMany(e => e.tasks)
                .WithMany(e => e.timesheet)
                .Map(m => m.ToTable("timesheet_tasks").MapLeftKey("timsheets_id").MapRightKey("etasks_id"));
            modelBuilder.Entity<Forum>();
        }
    }
}
