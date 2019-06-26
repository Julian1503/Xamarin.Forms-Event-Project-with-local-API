using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppGeneric
{
    public interface IRepositorio<T> where T : EntityBase
    {
        void Create(T entidad);

    }
}
