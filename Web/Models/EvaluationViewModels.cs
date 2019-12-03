using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenWeb.Models
{
    public class EvaluationViewModels
    {
        public int id { get; set; }

        public float autonomie { get; set; }

        public float collectif { get; set; }

        public float fiabilite { get; set; }

        public float performance { get; set; }

        public int? employee_U_ID { get; set; }

        public virtual EmployeeViewModels employee { get; set; }
    }
}