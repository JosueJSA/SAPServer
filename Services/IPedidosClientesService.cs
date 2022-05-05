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
    public interface IPedidosClientesService
    {
        [OperationContract]
        List<EPedidoCliente> GetPedidosClientesList(string criterio, DateTime fecha);
        [OperationContract]
        List<EPedidoCliente> GetCommonPedidosList();
        [OperationContract]
        List<EProductoComprado> GetProductosComprados(int clavePedido);
        [OperationContract]
        ECliente GetCliente(int IDCliente);
        [OperationContract]
        List<EProducto> GetProductosList();
        [OperationContract]
        List<string> GetClientesList();
        

    }
}
