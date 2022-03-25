using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    internal class EjemploService : IEjemploService
    {
        public bool MostrarEjemplo(string cadena)
        {
            return cadena == "Entendí el ejemplo";
        }
    }
}
