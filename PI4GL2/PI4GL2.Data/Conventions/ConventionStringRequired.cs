using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI4GL2.Data.Conventions
{
 public   class ConventionStringRequired:Convention
    {
        public ConventionStringRequired()
        {
            Properties<String>()
           .Configure(p => p.IsRequired());
        }
    }
}
