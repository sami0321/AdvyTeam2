using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.Models
{
    public class Employee
    {

        public int id { get; set; }
        public bool? dispo { get; set; }

        public string email { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }

        public string password { get; set; }

        public string picture { get; set; }

        public string role { get; set; }

        public string skills { get; set; }
    }
}