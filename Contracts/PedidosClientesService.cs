using Services;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class PedidosClientesService : IPedidosClientesService
    {
        private ObjectParameter key = new ObjectParameter("Key", typeof(int));
        private ObjectParameter message = new ObjectParameter("Message", typeof(string));
        private AnswerMessage answer = new AnswerMessage();

        public ECliente GetCliente(int IDCliente)
        {
            ECliente cliente = null;
            using (var context = new SAPContext())
            {
                 cliente = context.SPGCliente(IDCliente).ToList().First();
                cliente.Direcciones = context.SPGDirecciones(IDCliente).ToList();
            }
            return cliente;
        }

        public List<string> GetClientesList()
        {
            List<string> clientes = null;
            using (var context = new SAPContext())
            {
                var result = context.Cliente.Where(element => element.Status == "Activo");
                if (result != null)
                {
                    clientes = new List<string>();
                    result.ToList().ForEach(c => clientes.Add($"{c.Id}: {c.Nombre} {c.Apellido}"));
                }
            }
            return clientes;
        }

        public List<EPedidoCliente> GetCommonPedidosList()
        {
            List<EPedidoCliente> pedidos = null;
            using (var context = new SAPContext())
            {
                pedidos = context.SPGPedidosComunes().ToList();
            }
            return pedidos;
        }

        public List<EPedidoCliente> GetPedidosClientesList(string criterio, DateTime fecha)
        {
            List<EPedidoCliente> pedidos = null;
            using (var context = new SAPContext())
            {
                pedidos = context.SPGPedidosClientes(criterio, fecha).ToList();
            }
            return pedidos;
        }

        public List<EProductoComprado> GetProductosComprados(int clavePedido)
        {
            List<EProductoComprado> productos = null;
            using (var context = new SAPContext())
            {
                productos = context.SPGProductosComprados(clavePedido).ToList();
            }
            return productos;
        }

        public List<EProducto> GetProductosList()
        {
            using (var context = new SAPContext())
            {
                var result = context.SPGProductos("Todos", null, Convert.ToDateTime("1890-12-12"), "Activo").ToList();
                return result.Where(p => p.Cantidad > 0).ToList();
            }
        }
    }
}
