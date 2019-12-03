namespace Domaine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hr.evaluation")]
    public partial class evaluation
    {
        public int id { get; set; }

        public float autonomie { get; set; }

        public float collectif { get; set; }

        public float fiabilite { get; set; }

        public float performance { get; set; }

        public int? employee_U_ID { get; set; }

        public virtual employee employee { get; set; }
    }
}
