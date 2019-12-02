namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hr.referencecompetence")]
    public partial class referencecompetence
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public referencecompetence()
        {
            quiz = new HashSet<quiz>();
        }

        [Key]
        public int id_cf { get; set; }

        [StringLength(255)]
        public string description_c { get; set; }

        public int? niveauAcquis { get; set; }

        public int? competence_id_c { get; set; }

        public int? employee_U_ID { get; set; }

        public virtual competence competence { get; set; }

        public virtual employee employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<quiz> quiz { get; set; }
    }
}
