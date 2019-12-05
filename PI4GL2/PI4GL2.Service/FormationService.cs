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
   public class FormationService : Service<formation>, IFormationService
    {
       private static IDataBaseFactory Factory = new DataBaseFactory();

        private static IUnitOfWork utk = new UnitOfWork(Factory);

        public FormationService() : base(utk)
        {
        }
    }
}
