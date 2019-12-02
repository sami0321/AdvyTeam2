using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class FicheMetierModel
    {
       
      
        
        public int id_f { get; set; }

       
        public string description_f { get; set; }

        
        public string F_Famille_Competence { get; set; }

        
        public string nom_f { get; set; }

        
        public int? Employee_U_ID { get; set; }

        
        public virtual ICollection<employee> employee { get; set; }

        public virtual employee employee1 { get; set; }

    }
}