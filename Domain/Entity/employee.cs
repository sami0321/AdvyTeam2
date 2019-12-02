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
            referencecompetence = new HashSet<referencecompetence>();
            fichemetier1 = new HashSet<fichemetier>();
        }

        [Key]
        public int U_ID { get; set; }

        public long? U_Cin { get; set; }

        [StringLength(255)]
        public string U_FirstName { get; set; }

        [StringLength(255)]
        public string U_LastName { get; set; }

        [StringLength(255)]
        public string U_PASSSWORD { get; set; }

        [StringLength(255)]
        public string U_NAME { get; set; }
        public string AdressMail { get; set; }

        public long? U_PhoneNumber { get; set; }

        [StringLength(255)]
        public string U_Role { get; set; }

        public int? ficheMetier_id_f { get; set; }

        public virtual fichemetier fichemetier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<referencecompetence> referencecompetence { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fichemetier> fichemetier1 { get; set; }
    }
}
