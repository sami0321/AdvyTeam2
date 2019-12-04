using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenWeb.Models
{
    public class Eval360ViewModels
    {
        public int id { get; set; }

        public int? emp_U_ID { get; set; }

        public virtual EmployeeViewModels employee { get; set; }
    }
}