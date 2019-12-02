namespace Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hr.quiz")]
    public partial class quiz
    {
        [Key]
        public int id_q { get; set; }

        public int? ReferenceCompetence_id_cf { get; set; }

        public virtual referencecompetence referencecompetence { get; set; }
    }
}
