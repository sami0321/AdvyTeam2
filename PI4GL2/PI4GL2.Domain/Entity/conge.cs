namespace PI4GL2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hr.conge")]
    public partial class conge
    {
        public int id { get; set; }

        public DateTime? date_deb { get; set; }

        public DateTime? date_fin { get; set; }

        public int jour { get; set; }

        public int? employe_id { get; set; }

        public virtual employee employee { get; set; }
    }
}
