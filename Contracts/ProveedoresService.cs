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
    public class ProveedoresService : IProveedoresService
    {
        //    private ObjectParameter key = new ObjectParameter("Key", typeof(int));
        //    private ObjectParameter message = new ObjectParameter("Message", typeof(string));
        //    private AnswerMessage answer = new AnswerMessage();

        //    public AnswerMessage AddProveedor(EProveedor proveedor)
        //    {
        //        using (var context = new SAPContext())
        //        {
        //            using (var transaction = context.Database.BeginTransaction())
        //            {
        //                try
        //                {
        //                    //context.SPICliente(proveedor.Nombre, proveedor.Apellido, proveedor.CodigoPostal, proveedor.Telefono, proveedor.Ciudad, proveedor.Nacimiento, proveedor.Email, key, message);
        //                    answer.Key = Convert.ToInt32(key.Value);
        //                    answer.Message = Convert.ToString(message.Value);
        //                    if (answer.Key > 0)
        //                    {
        //                        proveedor.Direcciones.ForEach(direccion => context.Cliente_Direccion.Add(new Cliente_Direccion()
        //                        {
        //                            IdCliente = answer.Key,
        //                            Calle = direccion.Calle,
        //                            Numero = direccion.Numero,
        //                        }));
        //                    }
        //                    else
        //                    {
        //                        throw new Exception();
        //                    }
        //                    context.SaveChanges();
        //                    transaction.Commit();
        //                }
        //                catch (Exception)
        //                {
        //                    transaction.Rollback();
        //                    answer.Key = -1;
        //                    answer.Message = "Error al agregar al cliente";
        //                }
        //            }
        //        }
        //        return answer;
        //    }

        //    public EProveedor GetProveedor(int IDProveedor)
        //    {
        //        EProveedor proveedor = null;
        //        using (var context = new SAPContext())
        //        {
        //            proveedor = context.SPGCliente(IDProveedor).ToList().First();
        //            proveedor.Direcciones = context.SPGDirecciones(IDProveedor).ToList();
        //        }
        //        return proveedor;
        //    }

        //    public List<string> GetProveedoresList()
        //    {
        //        List<string> proveedores = null;
        //        using (var context = new SAPContext())
        //        {
        //            var result = context.Proveedor.Where(element => element.Status == "Activo");
        //            if (result != null)
        //            {
        //                proveedores = new List<string>();
        //                result.ToList().ForEach(c => proveedores.Add($"{c.Clave}: {c.Nombre} {c.Apellido}"));
        //            }
        //        }
        //        return proveedores;
        //    }

        //    public AnswerMessage UpdateProveedor(EProveedor proveedor)
        //    {
        //        using (var context = new SAPContext())
        //        {
        //            using (var transaction = context.Database.BeginTransaction())
        //            {
        //                try
        //                {
        //                    context.SPUCliente(cliente.Id, cliente.Nombre, cliente.Apellido, cliente.CodigoPostal, cliente.Telefono, cliente.Ciudad, cliente.Nacimiento, cliente.Email, key, message);
        //                    answer.Key = Convert.ToInt32(key.Value);
        //                    answer.Message = Convert.ToString(message.Value);
        //                    if (answer.Key > 0)
        //                    {
        //                        cliente.Direcciones.ForEach(d =>
        //                        {
        //                            var direccion = context.Cliente_Direccion.Find(d.Id);
        //                            if (direccion != null)
        //                            {
        //                                direccion.Calle = d.Calle;
        //                                direccion.Colonia = d.Colonia;
        //                                direccion.Numero = d.Numero;
        //                            }
        //                            else
        //                            {
        //                                context.Cliente_Direccion.Add(new Cliente_Direccion()
        //                                {
        //                                    IdCliente = cliente.Id,
        //                                    Numero = d.Numero,
        //                                    Calle = d.Calle,
        //                                    Colonia = d.Colonia
        //                                });
        //                            }
        //                        });
        //                    }
        //                    else
        //                    {
        //                        throw new Exception();
        //                    }
        //                    context.SaveChanges();
        //                    transaction.Commit();
        //                }
        //                catch (Exception ex)
        //                {
        //                    transaction.Rollback();
        //                    answer.Key = -1;
        //                    answer.Message = ex.Message;
        //                }
        //            }
        //        }
        //        return answer;
        //    }
    }

}

