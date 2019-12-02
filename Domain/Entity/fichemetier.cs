namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hr.fichemetier")]
    public partial class fichemetier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public fichemetier()
        {
            employee = new HashSet<employee>();
        }

        [Key]
        public int id_f { get; set; }

        [StringLength(255)]
        public string description_f { get; set; }

        [StringLength(255)]
        public string F_Famille_Competence { get; set; }

        [StringLength(255)]
        public string nom_f { get; set; }

        public int? Employee_U_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employee> employee { get; set; }

        public virtual employee employee1 { get; set; }
    }
}
