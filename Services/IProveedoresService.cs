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
    public interface IProveedoresService
    {
        [OperationContract]
        EProveedor GetProveedor(int IDProveedor);
        [OperationContract]
        List<EProveedor> GetProveedoresList(string criterio, string valor, string status);
        [OperationContract]
        AnswerMessage AddProveedor(EProveedor proveedor);
        [OperationContract]
        AnswerMessage UpdateProveedor(int oldClave, EProveedor proveedor);
        [OperationContract]
        AnswerMessage ChangeProveedorStatus(int idProveedor, string status);
    }
}