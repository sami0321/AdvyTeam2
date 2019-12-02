using Domain;
using MyFinance.Data.Infrastructure;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmployeService : Service <employee> , IEmployee
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);
        public EmployeService() : base(UOW)
        {

        }

        public IEnumerable<employee> ListeEmp()
        {
            throw new NotImplementedException();
        }
    }
}
