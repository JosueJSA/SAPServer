using Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    [ServiceContract]
    public interface IClientesService
    {
        [OperationContract]
        ECliente GetCliente(int IDCliente);
        [OperationContract]
        List<string> GetClientesList();
        [OperationContract]
        AnswerMessage AddCliente(ECliente cliente);
        [OperationContract]
        AnswerMessage UpdateCliente(ECliente cliente);
        [OperationContract]
        ECliente GetClienteByPedido(int IdPedido);
    }
}
