using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class NoteModel
    {
   

        [Key]
        public int N_ID { get; set; }

        [StringLength(255)]
        public string D_STATE { get; set; }

        public float? N_TOTAL { get; set; }

        public int? employee_U_ID { get; set; }

        public int? mission_M_ID { get; set; }
    }
}