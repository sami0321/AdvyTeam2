namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hr.mission")]
    public partial class mission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public mission()
        {
            notes = new HashSet<note>();
        }

        [Key]
        public int M_ID { get; set; }

        public DateTime? DATE_DEB { get; set; }

        public DateTime? DATE_FIN { get; set; }

        [StringLength(255)]
        public string M_DESCRIPTION { get; set; }

        [StringLength(255)]
        public string M_TITLE { get; set; }

        public int? manager_U_ID { get; set; }

        public virtual employee employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<note> notes { get; set; }
    }
}
