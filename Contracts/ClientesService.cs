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
    public class ClientesService : IClientesService
    {
        private ObjectParameter key = new ObjectParameter("Key", typeof(int));
        private ObjectParameter message = new ObjectParameter("Message", typeof(string));
        private AnswerMessage answer = new AnswerMessage();

        public AnswerMessage AddCliente(ECliente cliente)
        {
            using (var context = new SAPContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.SPICliente(cliente.Nombre, cliente.Apellido, cliente.CodigoPostal, cliente.Telefono, cliente.Ciudad, cliente.Nacimiento, cliente.Email, key, message);
                        answer.Key = Convert.ToInt32(key.Value);
                        answer.Message = Convert.ToString(message.Value);
                        if (answer.Key > 0)
                        {
                            cliente.Direcciones.ForEach(direccion => context.Cliente_Direccion.Add(new Cliente_Direccion()
                            {
                                IdCliente = answer.Key,
                                Calle = direccion.Calle,
                                Numero = direccion.Numero,
                                Colonia = direccion.Colonia
                            }));
                        }
                        else
                        {
                            throw new Exception();
                        }
                        context.SaveChanges();
                        transaction.Commit();
                    }catch (Exception)
                    {
                        transaction.Rollback();
                        answer.Key = -1;
                        answer.Message = "Error al agregar al cliente";
                    }
                }
            }
            return answer;
        }

        public AnswerMessage ChangeStatusCliente(int idCliente, string status)
        {
            using (var context = new SAPContext())
            {
                context.SPChangeStatusCliente(idCliente, status, key, message);
                answer.Key = Convert.ToInt32(key.Value);
                answer.Message = Convert.ToString(message.Value);
                return answer;
            }
        }

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

        public ECliente GetClienteByPedido(int IdPedido)
        {
            ECliente cliente = null;
            using (var context = new SAPContext())
            {
                var pedido = context.PedidoCliente.FirstOrDefault(p => p.Codigo == IdPedido);
                cliente = GetCliente(Convert.ToInt32(pedido.IdCliente));
            }
            return cliente;
        }

        public List<ECliente> GetClientes(string status, string nombre = null)
        {
            using (var context = new SAPContext())
            {
                List<ECliente> clientes = new List<ECliente>();
                try
                {
                    if (nombre == null)
                        clientes = context.SPGClientes(null, status).ToList();
                    else
                        clientes = context.SPGClientes($"%{nombre}%", status).ToList();
                    return clientes;   
                }catch(Exception)
                {
                    return new List<ECliente>();
                }
            }
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

        public AnswerMessage UpdateBasicClient(ECliente cliente)
        {
            using (var context = new SAPContext())
            {
                var c = context.Cliente.Find(cliente.Id);
                c.Email = cliente.Email;
                c.CodigoPostal = cliente.CodigoPostal;
                c.Nombre = cliente.Nombre;
                c.Apellido = cliente.Apellido;
                c.Status = cliente.Status;
                c.Ciudad = cliente.Ciudad;
                c.Telefono = cliente.Telefono;
                c.Nacimiento = cliente.Nacimiento;
                context.SaveChanges();
                answer.Key = 1;
                return answer;
            }
        }

        public AnswerMessage UpdateCliente(ECliente cliente)
        {
            using (var context = new SAPContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.SPUCliente(cliente.Id, cliente.Nombre, cliente.Apellido, cliente.CodigoPostal, cliente.Telefono, cliente.Ciudad, cliente.Nacimiento, cliente.Email, key, message);
                        answer.Key = Convert.ToInt32(key.Value);
                        answer.Message = Convert.ToString(message.Value);
                        if (answer.Key > 0)
                        {
                            cliente.Direcciones.ForEach(d =>
                            {
                                var direccion = context.Cliente_Direccion.Find(d.Id);
                                if (direccion != null)
                                {
                                    direccion.Calle = d.Calle;
                                    direccion.Colonia = d.Colonia;
                                    direccion.Numero = d.Numero;
                                }
                                else
                                {
                                    context.Cliente_Direccion.Add(new Cliente_Direccion()
                                    {
                                        IdCliente = cliente.Id,
                                        Numero = d.Numero,
                                        Calle = d.Calle,
                                        Colonia = d.Colonia
                                    });
                                }
                            });
                        }
                        else
                        {
                            throw new Exception();
                        }
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        answer.Key = -1;
                        answer.Message = ex.Message;
                    }
                }
            }
            return answer;
        }
    }
}
