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
    public class FicheMetierService : Service <fichemetier>, IFicheMetier
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);
        public FicheMetierService() : base(UOW)
        {

        }

        public IEnumerable<fichemetier> GetFichemetiers(string name)
        {
            return GetMany((f=>f.F_Famille_Competence.ToLower().Equals(name)), null);
        }

        public IEnumerable<fichemetier> ListFiche()
        {
            throw new NotImplementedException();
        }
    }

}

