namespace Domain

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hr.employee")]
    public partial class employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public employee()
        {
            missions = new HashSet<mission>();
            referencecompetences = new HashSet<referencecompetence>();
            notes = new HashSet<note>();
            employee1 = new HashSet<employee>();
        }

        [Key]
        public int U_ID { get; set; }

        public long? U_Cin { get; set; }

        [StringLength(255)]
        public string U_FirstName { get; set; }

        [StringLength(255)]
        public string U_LastName { get; set; }
        public string AdressMail { get; set; }

        [StringLength(255)]
        public string U_PASSSWORD { get; set; }

        [StringLength(255)]
        public string U_NAME { get; set; }

        public long? U_PhoneNumber { get; set; }

        [StringLength(255)]
        public string U_Role { get; set; }

        public int? ficheMetier_id_f { get; set; }

        public int? manager_U_ID { get; set; }

        public virtual fichemetier fichemetier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<mission> missions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<referencecompetence> referencecompetences { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<note> notes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<employee> employee1 { get; set; }

        public virtual employee employee2 { get; set; }
    }
}
