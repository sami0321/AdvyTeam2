namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hr.result")]
    public partial class result
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        [Column("result")]
        [StringLength(255)]
        public string result1 { get; set; }

        public double score { get; set; }

        [StringLength(255)]
        public string statut { get; set; }

        public long? idcandidate { get; set; }

        public int? idtopic { get; set; }

        public virtual user user { get; set; }

        public virtual topic topic { get; set; }
    }
}
