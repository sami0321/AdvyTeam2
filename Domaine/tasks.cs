namespace Domaine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hr.tasks")]
    public partial class tasks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tasks()
        {
            timesheet = new HashSet<timesheet>();
        }

        public int id { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int Realtime_duration { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        public int estimated_duration { get; set; }

        [Column(TypeName = "bit")]
        public bool? isvalid { get; set; }

        public int? st { get; set; }

        public int? employee_id { get; set; }

        public int? project_id { get; set; }

        public virtual employee employee { get; set; }

        public virtual project project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<timesheet> timesheet { get; set; }
    }
}
