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
        private ObjectParameter key = new ObjectParameter("Key", typeof(int));
        private ObjectParameter message = new ObjectParameter("Message", typeof(string));
        private AnswerMessage answer = new AnswerMessage();

        public EProveedor GetProveedor(int idProveedor)
        {
            EProveedor proveedor = null;
            using (var context = new SAPContext())
            {
                try
                {
                    proveedor = context.SPGProveedor("Clave", idProveedor.ToString(), "Activo").ToList().First();
                }catch (Exception)
                {
                    return null;
                }
            }
            return proveedor;
        }

        public AnswerMessage AddProveedor(EProveedor proveedor)
        {
            using (var context = new SAPContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.SPIProveedor(proveedor.Email, proveedor.Nombre, proveedor.Rfc, proveedor.CategoriaInsumo, proveedor.Telefono, proveedor.DireccionEmpresa, key, message);
                        answer.Key = Convert.ToInt32(key.Value);
                        answer.Message = Convert.ToString(message.Value);
                        if (answer.Key < 0)
                        {
                            throw new Exception();
                        }
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        answer.Key = -1;
                        answer.Message = "Error al agregar al proveedor";
                    }
                }
            }
            return answer;
        }   

        public List<EProveedor> GetProveedoresList(string criterio, string valor = null, string status = null)
        {
            try
            {
                List<EProveedor> proveedoresList = new List<EProveedor>();
                using (var context = new SAPContext())
                {
                    proveedoresList = context.SPGProveedor(criterio, valor, status).ToList();
                }
                return proveedoresList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public AnswerMessage UpdateProveedor(int oldClave, EProveedor proveedor)
        {
            using (var context = new SAPContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.SPUProveedor(oldClave, proveedor.Email, proveedor.Nombre, proveedor.Rfc, proveedor.CategoriaInsumo, proveedor.Telefono, proveedor.DireccionEmpresa, key, message);
                        answer.Key = Convert.ToInt32(key.Value);
                        answer.Message = Convert.ToString(message.Value);
                        if (answer.Key < 0)
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

        public AnswerMessage ChangeProveedorStatus(int idProveedor, string status)
        {
            using (var context = new SAPContext())
            {
                context.SPChangeStatusProveedor(idProveedor, status, key, message);
                answer.Key = Convert.ToInt32(key.Value);
                answer.Message = Convert.ToString(message.Value);
            }
            return answer;
        }


    }
}


