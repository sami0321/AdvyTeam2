using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class QuizModel
    {
        
        public int id_q { get; set; }

        public int? ReferenceCompetence_id_cf { get; set; }

        public virtual referencecompetence referencecompetence { get; set; }
    }
}