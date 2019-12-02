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
    public class ReferenceCompetenceService :Service<referencecompetence> , IReferenceCompetence
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);
        public ReferenceCompetenceService() : base(UOW)
        {

        }

        public IEnumerable<referencecompetence> GetEmployeeCompetences(string familleCompetence, int empId)
        {
            return GetMany((rc => rc.competence.Famille.ToUpper().Equals(familleCompetence.ToUpper()) && rc.employee_U_ID == empId), null);
        }

        public bool EmpNeedsToBeTested(int idReferenceCompetence)
        {
            referencecompetence rc = GetById(idReferenceCompetence);
            return (rc.niveauAcquis < (rc.competence.niveau / 2));
        }
    }
}
