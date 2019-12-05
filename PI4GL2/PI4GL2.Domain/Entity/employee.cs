namespace PI4GL2.Domain
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
            conges = new HashSet<conge>();
            formations = new HashSet<formation>();
        }

        public int id { get; set; }
        public Boolean state { get; set; }
        public long? cin { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string firstName { get; set; }

        [StringLength(255)]
        public string lastName { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        public long? phonenumber { get; set; }

        [StringLength(255)]
        public string role { get; set; }

        public float salaire { get; set; }

        public int? manager_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<conge> conges { get; set; }

        public virtual manager manager { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<formation> formations { get; set; }
    }
}
