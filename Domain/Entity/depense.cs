namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hr.depense")]
    public partial class depense
    {
        [Key]
        public int D_ID { get; set; }

        [StringLength(255)]
        public string D_CATEGORY { get; set; }

        public DateTime? D_DATE { get; set; }

        [StringLength(255)]
        public string D_Description { get; set; }

        [StringLength(255)]
        public string D_MOY_PAYM { get; set; }

        [StringLength(255)]
        public string D_STATE { get; set; }

        [StringLength(255)]
        public string D_TITLE { get; set; }

        public float? D_TTC { get; set; }

        public float? D_TVA { get; set; }

        public int? note_N_ID { get; set; }

        public virtual note note { get; set; }
    }
}
