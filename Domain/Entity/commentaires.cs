namespace Domaine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hr.commentaires")]
    public partial class commentaires
    {
        public int id { get; set; }

        public float note { get; set; }

        [StringLength(255)]
        public string text { get; set; }

        public int? employ_U_ID { get; set; }

        public virtual employee employee { get; set; }
    }
}
