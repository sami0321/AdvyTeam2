using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IReferenceCompetence
    {
        IEnumerable<referencecompetence> GetEmployeeCompetences(string familleCompetence, int empId);
        bool EmpNeedsToBeTested(int idReferenceCompetence);
    }
}
