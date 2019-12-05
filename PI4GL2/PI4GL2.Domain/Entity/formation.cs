namespace PI4GL2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hr.formation")]
    public partial class formation
    {
        public int id { get; set; }

        [StringLength(255)]
        public string etablissement { get; set; }

        [StringLength(255)]
        public string nom { get; set; }



        [StringLength(255)]
        public string skill { get; set; }

        [StringLength(255)]
        public string type { get; set; }

        public int? employee_id { get; set; }

        public virtual employee employee { get; set; }
    }

}
