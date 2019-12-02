using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class EmployeModel
    {
       
        public int U_ID { get; set; }

        public long? U_Cin { get; set; }

        
        public string U_FirstName { get; set; }

        public string AdresseMail { get; set; }
        public string U_LastName { get; set; }

        
        public string U_PASSSWORD { get; set; }

       
        public string U_NAME { get; set; }

        public long? U_PhoneNumber { get; set; }

       
        public string U_Role { get; set; }

        public int? ficheMetier_id_f { get; set; }

        public virtual fichemetier fichemetier { get; set; }

        
        public virtual ICollection<referencecompetence> referencecompetence { get; set; }

        
        public virtual ICollection<fichemetier> fichemetier1 { get; set; }

    }
}