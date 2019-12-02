namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hr.user")]
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            reclamation = new HashSet<reclamation>();
            result = new HashSet<result>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id { get; set; }

        [Column(TypeName = "bit")]
        public bool actif { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthDate { get; set; }

        [StringLength(255)]
        public string cin { get; set; }

        [StringLength(255)]
        public string contrat_type { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string firstName { get; set; }

        [StringLength(255)]
        public string lastName { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string phoneNumber { get; set; }

        [StringLength(255)]
        public string role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reclamation> reclamation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<result> result { get; set; }
    }
}
