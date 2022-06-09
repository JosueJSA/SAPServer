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
        List<EPedidoCliente> GetPedidosClientesList(string status, int? codigo, DateTime? fecha);
        [OperationContract]
        List<EPedidoCliente> GetCommonPedidosList();
        [OperationContract]
        List<EProductoComprado> GetProductosComprados(int clavePedido);
        [OperationContract]
        List<EProducto> GetProductosList();
        [OperationContract]
        AnswerMessage AddPedidoCliente(EPedidoCliente pedido, List<EProductoComprado> productos, int idCliente, int idDireccion);
        [OperationContract]
        string CheckProductosSeleccionados(List<EProductoComprado> productos);
        [OperationContract]
        AnswerMessage ChangeStatusPedidoCliente(int IdPedido, string status);
        [OperationContract]
        EPedidoClienteDetallado GetPedidoCliente(int codigo);
        [OperationContract]
        AnswerMessage RestablishChanges(List<EProductoComprado> productos);
        [OperationContract]
        AnswerMessage CancelPedidoCliente(int IdPedido, string motivo, List<EProductoComprado> productos = null);
    }
}
