namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain;

    public partial class Context : DbContext
    {
        public Context()
            : base("Context")
        {
        }

        public virtual DbSet<answer> answers { get; set; }
        public virtual DbSet<competence> competences { get; set; }
        public virtual DbSet<depense> depenses { get; set; }
        public virtual DbSet<domain> domains { get; set; }
        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<fichemetier> fichemetiers { get; set; }
        public virtual DbSet<mission> missions { get; set; }
        public virtual DbSet<note> notes { get; set; }
        public virtual DbSet<question> questions { get; set; }
        public virtual DbSet<quiz> quizs { get; set; }
        public virtual DbSet<reclamation> reclamations { get; set; }
        public virtual DbSet<referencecompetence> referencecompetences { get; set; }
        public virtual DbSet<result> results { get; set; }
        public virtual DbSet<topic> topics { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<answer>()
                .Property(e => e.type_reponse)
                .IsUnicode(false);

            modelBuilder.Entity<competence>()
                .Property(e => e.description_c)
                .IsUnicode(false);

            modelBuilder.Entity<competence>()
                .Property(e => e.Famille)
                .IsUnicode(false);

            modelBuilder.Entity<competence>()
                .Property(e => e.metier)
                .IsUnicode(false);

            modelBuilder.Entity<competence>()
                .Property(e => e.nom_c)
                .IsUnicode(false);

            modelBuilder.Entity<competence>()
                .HasMany(e => e.referencecompetence)
                .WithOptional(e => e.competence)
                .HasForeignKey(e => e.competence_id_c);

            modelBuilder.Entity<depense>()
                .Property(e => e.D_CATEGORY)
                .IsUnicode(false);

            modelBuilder.Entity<depense>()
                .Property(e => e.D_Description)
                .IsUnicode(false);

            modelBuilder.Entity<depense>()
                .Property(e => e.D_MOY_PAYM)
                .IsUnicode(false);

            modelBuilder.Entity<depense>()
                .Property(e => e.D_STATE)
                .IsUnicode(false);

            modelBuilder.Entity<depense>()
                .Property(e => e.D_TITLE)
                .IsUnicode(false);

            modelBuilder.Entity<domain>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<domain>()
                .HasMany(e => e.topic)
                .WithOptional(e => e.domain)
                .HasForeignKey(e => e.domain_id);

            modelBuilder.Entity<employee>()
                .Property(e => e.U_FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
              .Property(e => e.AdressMail)
              .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.U_LastName)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.U_PASSSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.U_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.U_Role)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.missions)
                .WithOptional(e => e.employee)
                .HasForeignKey(e => e.manager_U_ID);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.referencecompetences)
                .WithOptional(e => e.employee)
                .HasForeignKey(e => e.employee_U_ID);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.notes)
                .WithOptional(e => e.employee)
                .HasForeignKey(e => e.employee_U_ID);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.employee1)
                .WithOptional(e => e.employee2)
                .HasForeignKey(e => e.manager_U_ID);

            modelBuilder.Entity<fichemetier>()
                .Property(e => e.description_f)
                .IsUnicode(false);

            modelBuilder.Entity<fichemetier>()
                .Property(e => e.F_Famille_Competence)
                .IsUnicode(false);

            modelBuilder.Entity<fichemetier>()
                .Property(e => e.nom_f)
                .IsUnicode(false);

            modelBuilder.Entity<fichemetier>()
                .HasMany(e => e.employee)
                .WithOptional(e => e.fichemetier)
                .HasForeignKey(e => e.ficheMetier_id_f);

            modelBuilder.Entity<mission>()
                .Property(e => e.M_DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.M_TITLE)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .HasMany(e => e.notes)
                .WithOptional(e => e.mission)
                .HasForeignKey(e => e.mission_M_ID);

            modelBuilder.Entity<note>()
                .Property(e => e.D_STATE)
                .IsUnicode(false);

            modelBuilder.Entity<note>()
                .HasMany(e => e.depenses)
                .WithOptional(e => e.note)
                .HasForeignKey(e => e.note_N_ID);

            modelBuilder.Entity<question>()
                .Property(e => e.complexity)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.enonce)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.indice)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.reponsejuste)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<question>()
                .HasMany(e => e.answer)
                .WithOptional(e => e.question)
                .HasForeignKey(e => e.question_id);

            modelBuilder.Entity<reclamation>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<reclamation>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<reclamation>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<reclamation>()
                .Property(e => e.objet)
                .IsUnicode(false);

            modelBuilder.Entity<referencecompetence>()
                .Property(e => e.description_c)
                .IsUnicode(false);

            modelBuilder.Entity<referencecompetence>()
                .HasMany(e => e.quiz)
                .WithOptional(e => e.referencecompetence)
                .HasForeignKey(e => e.ReferenceCompetence_id_cf);

            modelBuilder.Entity<result>()
                .Property(e => e.result1)
                .IsUnicode(false);

            modelBuilder.Entity<result>()
                .Property(e => e.statut)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .Property(e => e.image)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<topic>()
                .HasMany(e => e.question)
                .WithOptional(e => e.topic)
                .HasForeignKey(e => e.topic_id);

            modelBuilder.Entity<topic>()
                .HasMany(e => e.reclamation)
                .WithOptional(e => e.topic)
                .HasForeignKey(e => e.topic_id);

            modelBuilder.Entity<topic>()
                .HasMany(e => e.result)
                .WithOptional(e => e.topic)
                .HasForeignKey(e => e.idtopic);

            modelBuilder.Entity<user>()
                .Property(e => e.cin)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.contrat_type)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.phoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.role)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.reclamation)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.candidate_id);

            modelBuilder.Entity<user>()
                .HasMany(e => e.result)
                .WithOptional(e => e.user)
                .HasForeignKey(e => e.idcandidate);
        }

      //  public System.Data.Entity.DbSet<Web.Models.NoteModel> NoteModels { get; set; }

        // public System.Data.Entity.DbSet<Web.Models.NoteModel> NoteModels { get; set; }
    }
}
