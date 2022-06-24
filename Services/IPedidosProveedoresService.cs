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
    public interface IPedidosProveedoresService
    {
        [OperationContract]
        AnswerMessage AddPedidoProveedor(EPedidoProveedor pedido);

        [OperationContract]
        AnswerMessage ChangeStatusPeidoProveedor(int idPedido, string Status);

        [OperationContract]
        List<EPedidoProveedor> GetPedidosProveedores(int? id);
    }
}
