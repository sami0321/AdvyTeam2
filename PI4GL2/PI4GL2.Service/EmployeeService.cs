using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI4GL2.Service.Pattern;
using PI4GL2.Domain;
using PI4GL2.Data.Infrastructure;
namespace PI4GL2.Service
{
   public class EmployeeService : Service<employee>, IEmployee
    {
        static IDataBaseFactory Factory = new DataBaseFactory();

        static IUnitOfWork utk = new UnitOfWork(Factory);

        public EmployeeService() : base(utk)
        {
        }
    }
}
