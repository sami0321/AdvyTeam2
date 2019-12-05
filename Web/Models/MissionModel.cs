using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
     public class MissionModel
    {
        public int M_ID { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DATE_DEB { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DATE_FIN { get; set; }

       
        public string M_DESCRIPTION { get; set; }

        
        public string M_TITLE { get; set; }

        public int? manager_U_ID { get; set; }

        public virtual employee employee { get; set; }

        
        public virtual ICollection<note> notes { get; set; }
    }
}