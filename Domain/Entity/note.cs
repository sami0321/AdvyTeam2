namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hr.note")]
    public partial class note
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public note()
        {
            depenses = new HashSet<depense>();
        }

        [Key]
        public int N_ID { get; set; }

        [StringLength(255)]
        public string D_STATE { get; set; }

        public float? N_TOTAL { get; set; }

        public int? employee_U_ID { get; set; }

        public int? mission_M_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<depense> depenses { get; set; }

        public virtual employee employee { get; set; }

        public virtual mission mission { get; set; }
    }
}
