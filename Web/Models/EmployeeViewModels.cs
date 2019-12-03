using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenWeb.Models
{
    public class EmployeeViewModels
    {
        [Key]
        public int U_ID { get; set; }

        public long? U_Cin { get; set; }

        [StringLength(255)]
        public string U_FirstName { get; set; }

        [StringLength(255)]
        public string U_LastName { get; set; }

        [StringLength(255)]
        public string U_PASSSWORD { get; set; }

        [StringLength(255)]
        public string U_NAME { get; set; }

        public long? U_PhoneNumber { get; set; }

        [StringLength(255)]
        public string U_Role { get; set; }

        public virtual ICollection<CommentaireViewModels> commentaires { get; set; }

        public virtual ICollection<Eval360ViewModels> eval360 { get; set; }

        public virtual ICollection<ReclamationViewModels> reclamation { get; set; }

        public virtual ICollection<EvaluationViewModels> evaluation { get; set; }
    }
}