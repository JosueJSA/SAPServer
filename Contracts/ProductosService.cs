using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.Win32;
using Services;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Contracts
{
    public class ProductosService : IProductosService
    {
        private ObjectParameter key = new ObjectParameter("Key", typeof(int));
        private ObjectParameter message = new ObjectParameter("Message", typeof(string));
        private AnswerMessage answer = new AnswerMessage();

        public AnswerMessage AddProducto(EProducto producto, EReceta receta = null)
        {  
            using (var context = new SAPContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        int claveReceta = -1;
                        if (receta != null)
                        {
                            var newReceta = new Receta();
                            context.Receta.Add(newReceta = new Receta() { Descripcion = receta.Descripcion });
                            context.SaveChanges();

                            receta.Ingredientes.ForEach(i =>
                            {
                                context.Ingrediente.Add(new Ingrediente() { ClaveReceta = newReceta.Clave, CodigoInsumo = i.CodigoInsumo, Cantidad = i.CantidadIngrediente });
                            });
                            context.SaveChanges();
                            claveReceta = newReceta.Clave;
                        }

                        context.SPIProducto(claveReceta, producto.PrecioVenta, producto.PrecioCompra, producto.Cantidad, producto.Nombre, producto.Foto, producto.Descripcion, producto.Restricciones, key, message);
                        answer.Key = Convert.ToInt32(key.Value);
                        answer.Message = Convert.ToString(message.Value);
                        if (answer.Key < 0)
                            throw new Exception(answer.Message);

                        context.SaveChanges();
                        transaction.Commit();

                    }catch (Exception ex)
                    {
                        answer.Key = -1;
                        answer.Message = ex.Message;
                        transaction.Rollback();
                    }
                }
            }
            return answer;
        }

        public AnswerMessage ChangeProductoStatus(int productoID, string status)
        {
            using (var context = new SAPContext())
            {
                context.SPChangeStatusProducto(productoID, status, key, message);
                answer.Key = Convert.ToInt32(key.Value);
                answer.Message = Convert.ToString(message.Value);
            }
            return answer;
        }

        public string CheckIngredientesStatus(List<EIngrediente> ingredientes)
        {
            string response = string.Empty;
            using (var context = new SAPContext())
            {
                ingredientes.ForEach(ingrediente =>
                {
                    if (!context.Insumo.Any(i => i.Codigo == ingrediente.CodigoInsumo && i.Status == "Activo"))
                        response = $"El insumo #{ingrediente.CodigoInsumo} - {ingrediente.NombreInsumo}, no aparece en la lista de insumos activos, es probable" +
                        $" que haya sido dado de baja recientemente";
                });
            }
            return response;
        }

        public List<EInsumo> GetIngredientes()
        {
            List<EInsumo> insumosList = null;
            using (var context = new SAPContext())
            {
                insumosList = context.SPGInsumos("Todos", null, null, "Activo").ToList();
            }
            return insumosList;
        }

        public List<EProducto> GetProductosList(string criterio, string valor, DateTime fecha, string status)
        {
            List<EProducto> productosList = null;
            using (var context = new SAPContext())
            {
                productosList = context.SPGProductos(criterio, valor, fecha, status).ToList();
            }
            return productosList;
        }

        public EReceta GetReceta(int clave)
        {
            EReceta receta = null;
            using (var context = new SAPContext())
            {
                receta = new EReceta();
                receta.Clave = clave;
                var ingredientes = context.SPGIngredientes(clave);
                receta.Ingredientes = ingredientes.ToList();
                var query = context.Receta.Where(r => r.Clave == clave).Select(r => r.Descripcion);
                if (query != null && query.Count() > 0)
                    receta.Descripcion = query.First();
                else
                    receta = null;
            }
            return receta;
        }

        public bool IsDuplicated(string nombreActual, string nombreABuscar)
        {
            bool returnValue = false;
            using (var context = new SAPContext())
            {
                if (nombreActual.ToLower() != nombreABuscar.ToLower() && context.ProductoVenta.Any(producto => producto.Nombre.ToLower() == nombreABuscar.ToLower()))
                    returnValue = true;
            }
            return returnValue;
        }

        public AnswerMessage UpdateProducto(EProducto producto, EReceta receta = null)
        { 
            using (var context = new SAPContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (receta != null)
                        {
                            var recetaAux = new Receta();
                            context.Ingrediente.RemoveRange(context.Ingrediente.Where(x => x.ClaveReceta == producto.CodigoReceta));
                            context.SaveChanges();
                            if (context.Receta.Any(r => r.Clave == receta.Clave))
                            {
                                recetaAux = context.Receta.Where(r => r.Clave == producto.CodigoReceta).First();
                                recetaAux.Descripcion = receta.Descripcion;
                            }
                            else
                            {
                                recetaAux = new Receta();
                                context.Receta.Add(recetaAux = new Receta() { Descripcion = receta.Descripcion });
                                context.SaveChanges();
                                producto.CodigoReceta = recetaAux.Clave;
                            }
                            context.SaveChanges();
                            receta.Ingredientes.ForEach(i =>
                            {
                                context.Ingrediente.Add(new Ingrediente() { ClaveReceta = recetaAux.Clave, CodigoInsumo = i.CodigoInsumo, Cantidad = i.CantidadIngrediente });
                            });
                            context.SaveChanges();
                        }
                        else
                        {
                            var productoAux = context.ProductoVenta.Where(p => p.Codigo == producto.Codigo).First();
                            if(context.Receta.Any(r => r.Clave == productoAux.CodigoReceta))
                            {
                                context.Ingrediente.RemoveRange(context.Ingrediente.Where(x => x.ClaveReceta == productoAux.CodigoReceta));
                                context.SaveChanges();
                                context.Receta.Remove(context.Receta.Where(r => r.Clave == productoAux.CodigoReceta).First());
                                context.SaveChanges();
                            }
                        }

                        context.SPUProducto(producto.Codigo, producto.CodigoReceta, producto.PrecioVenta, producto.PrecioCompra, producto.Cantidad, producto.Nombre, producto.Foto, producto.Descripcion, producto.Restricciones, key, message);
                        answer.Key = Convert.ToInt32(key.Value);
                        answer.Message = Convert.ToString(message.Value);
                        if (answer.Key < 0)
                            throw new Exception(answer.Message);

                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        answer.Message = ex.Message;
                        transaction.Rollback(); 
                    }
                }
            }
            return answer;
        }
    }
}
