using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Web.Models
{
   
    public class CompetenceModel
    {

        
        public int id_c { get; set; }

        
        public string descriptionc { get; set; }

       
        public string Famille { get; set; }

        public int? niveau { get; set; }

        public string nomc { get; set; }

       
        public string metier { get; set; }

       
        public virtual ICollection<referencecompetence> referencecompetence { get; set; }



    }
}