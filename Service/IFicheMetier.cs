using Domain;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IFicheMetier : IService<fichemetier>
    {
        IEnumerable<fichemetier> ListFiche();
        IEnumerable<fichemetier> GetFichemetiers(string name);

    }


}