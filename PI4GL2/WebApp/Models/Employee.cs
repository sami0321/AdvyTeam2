using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Employee
    {

        public int id { get; set; }

        public long? cin { get; set; }

        public string email { get; set; }
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string password { get; set; }

        public long phonenumber { get; set; }
        public string role { get; set; }

        public float salaire { get; set; }
    }
    
}