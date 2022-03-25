using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [ServiceContract]
    public interface IEjemploService
    {
        [OperationContract]
        bool MostrarEjemplo(string cadena);
    }
}
