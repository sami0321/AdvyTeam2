namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hr.competence")]
    public partial class competence
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public competence()
        {
            referencecompetence = new HashSet<referencecompetence>();
        }

        [Key]
        public int id_c { get; set; }

        [StringLength(255)]
        public string description_c { get; set; }

        [StringLength(255)]
        public string Famille { get; set; }

        public int? niveau { get; set; }

        [StringLength(255)]
        public string nom_c { get; set; }

        [StringLength(255)]
        public string metier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<referencecompetence> referencecompetence { get; set; }
    }
}
