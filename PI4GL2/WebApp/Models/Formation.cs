using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Formation
    {
        public int id { get; set; }

        public string etablissement { get; set; }

        public string nom { get; set; }

        public string skill { get; set; }
        public string type { get; set; }

        public int? employee_id { get; set; }

    }
}