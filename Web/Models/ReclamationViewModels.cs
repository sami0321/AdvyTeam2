using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenWeb.Models
{
    public class ReclamationViewModels
    {
        public int id { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

     //   [StringLength(255)]
       // public string etat { get; set; }

        [StringLength(255)]
        public string titre { get; set; }

        

        // public virtual EmployeeViewModels employee { get; set; }
    }
}