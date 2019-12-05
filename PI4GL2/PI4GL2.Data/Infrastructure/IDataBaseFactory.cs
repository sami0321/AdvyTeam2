using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI4GL2.Data.Infrastructure
{
    public interface IDataBaseFactory:IDisposable
    {
        MyDBContext Ctxt { get; }
    }
}
