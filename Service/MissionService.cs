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
   public class MissionService : Service<mission>, IMission
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);

        public MissionService() : base(UOW)
        {
        }

        public IEnumerable<mission> GetMission(string name)
        {
           
            return GetMany((f => f.M_TITLE.ToLower().Equals(name)), null);
        }


        public IEnumerable<mission> ListMission()
        {
            throw new NotImplementedException();
        }
    }
 }
    

