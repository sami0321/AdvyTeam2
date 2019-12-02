using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ReferenceCompetenceModel
    {
       
        public int id_cf { get; set; }

        
        public string description_c { get; set; }

        public int? niveauAcquis { get; set; }

        public int? competence_id_c { get; set; }

        public int? employee_U_ID { get; set; }

        public virtual CompetenceModel competence { get; set; }

        public virtual employee employee { get; set; }

        public virtual ICollection<quiz> quiz { get; set; }

    }
}