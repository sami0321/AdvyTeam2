using Domain;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    interface IEmployee : IService<employee>
    {
        IEnumerable<employee> ListeEmp();
    }
}
