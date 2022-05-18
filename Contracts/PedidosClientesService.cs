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
        private Dictionary<string, string> PedidosStatus = new Dictionary<string, string>()
        {
            {"Ordenado", "En preparación" },
            {"En preparación", "Preparado" },
            {"Preparado", "Entregado" }
        };

        public AnswerMessage AddPedidoCliente(EPedidoCliente pedido, List<EProductoComprado> productos, int idCliente, int idDireccion)
        {
            using (var context = new SAPContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.SPIPedidoCliente(pedido.CostoTotal, Convert.ToInt32(pedido.Cantidad), pedido.TipoPedido, idCliente, idDireccion, key, message);
                        answer.Key = Convert.ToInt32(key.Value);
                        answer.Message = Convert.ToString(message.Value);
                        if (answer.Key < 0)
                            throw new Exception("No se ha podido registrar el pedido del cleinte");
                        productos.ForEach(p => context.Orden.Add(new Orden()
                        {
                            CodigoPedido = answer.Key,
                            CodigoProductoVenta = p.CodigoProductoVenta,
                            Cantidad = p.Cantidad,
                            Precio = p.Precio
                        }));
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        answer.Key = -1;
                        answer.Message = "Error en servidor";
                    }
                }
            }
            return answer;
        }

        private void UpdateInsumos(SAPContext context, List<EProductoComprado> productos)
        {
            string mensaje = "";
            if (string.IsNullOrEmpty(mensaje = CheckProductosSeleccionados(productos)))
            {
                productos.ForEach(p =>
                {
                    if (p.CodigoReceta >= 0)
                    {
                        context.Ingrediente.Where(i => i.ClaveReceta == p.CodigoReceta).ToList().ForEach(item =>
                        {
                            context.SPUCantidadInsumo(item.CodigoInsumo, p.Cantidad, p.CodigoReceta, key, message);
                            answer.Key = Convert.ToInt32(key.Value);
                            answer.Message = Convert.ToString(message.Value);
                            if (answer.Key < 0)
                                throw new Exception($"Error en la actualización del almacen en el producto: '{p.Nombre}'");
                        });
                    }
                    else
                    {
                        context.ProductoVenta.Find(p.CodigoProductoVenta).Cantidad -= p.Cantidad;
                        context.SaveChanges();
                    }
                });
            }
            else
            {
                throw new Exception(mensaje);
            }
        }

        public string CheckProductosSeleccionados(List<EProductoComprado> productos)
        {
            string answer = string.Empty;
            using (var context = new SAPContext())
            {
                foreach(var producto in productos) 
                { 
                    var result = context.ProductoVenta.Find(producto.CodigoProductoVenta);
                    if (result.Status != "Activo")
                        return $"El producto '{producto.Nombre}' ha sido dado de baja recientemente";
                    if (result.Cantidad < producto.Cantidad)
                        return $"El producto '{producto.Nombre}' solo tiene {result.Cantidad} unidades";
                }
            }
            return answer;
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

        public AnswerMessage ChangeStatusPedidoCliente(int IdPedido, string status)
        {
            using (var context = new SAPContext())
            {
                if (PedidosStatus.ContainsKey(status))
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            context.SPChangeStatusPedidoCliente(IdPedido, PedidosStatus[status], key, message);
                            answer.Key = Convert.ToInt32(key.Value);
                            answer.Message = Convert.ToString(message.Value);
                            if (answer.Key >= 0 && status == "Ordenado")
                            {
                                UpdateInsumos(context, GetProductosComprados(IdPedido));
                                answer.Key = Convert.ToInt32(key.Value);
                                answer.Message = Convert.ToString(message.Value);
                            }
                            transaction.Commit();
                            answer.Key = IdPedido;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            answer.Key = -1;
                            answer.Message = ex.Message;
                        }
                    }
                }else if (status == "Cancelado")
                {
                    context.SPChangeStatusPedidoCliente(IdPedido, status, key, message);
                    answer.Key = Convert.ToInt32(key.Value);
                    answer.Message = Convert.ToString(message.Value);
                }
                else
                {
                    answer.Key = -1;
                    answer.Message = "No se determinó un status claro en el envío de datos";
                }
            }
            return answer;
        }
    }
}
