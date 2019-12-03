namespace Domaine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hr.eval360")]
    public partial class eval360
    {
        public int id { get; set; }

        public int? emp_U_ID { get; set; }

        public virtual employee employee { get; set; }
    }
}
