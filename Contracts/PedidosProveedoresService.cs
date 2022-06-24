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
    public class PedidosProveedoresService : IPedidosProveedoresService
    {
        private ObjectParameter key = new ObjectParameter("Key", typeof(int));
        private ObjectParameter message = new ObjectParameter("Message", typeof(string));
        private AnswerMessage answer = new AnswerMessage();

        public AnswerMessage AddPedidoProveedor(EPedidoProveedor pedido)
        {
            using (var context = new SAPContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Pedido pedidog = new Pedido();
                        pedidog.CostoTotal = 0;
                        pedidog.Status = "Activo";
                        pedidog.Solicitud = DateTime.Now;
                        pedidog.Entrega = DateTime.Now;
                        context.Pedido.Add(pedidog);
                        context.SaveChanges();

                        PedidoProveedor pedidoProveedor = new PedidoProveedor()
                        {
                            Codigo = pedidog.Codigo,
                            ClaveProveedor = pedido.ClaveProveedor,
                            Cantidad = pedido.Cantidad,
                            TipoPedido = "Entrega",
                            Status = "Activo"
                        };

                        context.PedidoProveedor.Add(pedidoProveedor);
                        context.SaveChanges();

                        foreach (var insumo in pedido.Insumos)
                        {
                            context.OrdenAProveedor.Add(new OrdenAProveedor()
                            {
                                CodigoPedidoProveedor = pedidoProveedor.Codigo,
                                CodigoInsumo = insumo.CodigoInsumo,
                                Cantidad = insumo.Cantidad,
                                Precio = insumo.Precio
                            });
                        }

                        context.SaveChanges();
                        transaction.Commit();
                        answer.Key = pedidog.Codigo;
                        return answer;

                    }catch (Exception ex)
                    {
                        transaction.Rollback();
                        answer.Key = -1;
                        return answer;  
                    }
                }
            }
        }

        public AnswerMessage ChangeStatusPeidoProveedor(int idPedido, string Status)
        {
            using (var context = new SAPContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.SPChangePedidoProveedor(idPedido, Status, key, message);
                        answer.Key = Convert.ToInt32(key.Value);
                        answer.Message = Convert.ToString(message.Value);
                        if (answer.Key > 0)
                        {
                            if (Status == "Completado")
                            {
                                var pedido = context.SPGPedidoProveedor(idPedido).First();
                                foreach (var insumo in context.SPGInsumosPedidos(pedido.Codigo))
                                {
                                    context.SPUInsumoCantidad(insumo.CodigoInsumo, insumo.Cantidad, key, message);
                                }
                            }
                            context.SaveChanges();
                        }
                        else
                        {
                            return answer;
                        }
                        context.SaveChanges();
                        transaction.Commit();
                        answer.Key = 1;
                        return answer;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        answer.Key = -1;
                        return answer;
                    }
                }
            }
        }

        public List<EPedidoProveedor> GetPedidosProveedores(int? id = null)
        {
            using (var context = new SAPContext())
            {
                try
                {
                    var pedidos = context.SPGPedidoProveedor(id).ToList();
                    foreach(var p in pedidos)
                    {
                        p.Insumos = context.SPGInsumosPedidos(p.Codigo).ToList();
                    }
                    return pedidos;
                }catch (Exception)
                {
                    return new List<EPedidoProveedor>();
                }
            }
        }
    }
}
