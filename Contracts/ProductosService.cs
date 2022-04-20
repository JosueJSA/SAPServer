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

        public AnswerMessage AddProducto(EProducto producto, EReceta receta)
        {  
            using (var context = new SAPContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var newReceta = new Receta();  
                        context.Receta.Add(newReceta = new Receta() { Descripcion = receta.Descripcion });
                        context.SaveChanges();

                        receta.Ingredientes.ForEach(i =>
                        {
                            context.Ingrediente.Add(new Ingrediente() { ClaveReceta = newReceta.Clave, CodigoInsumo = i.CodigoInsumo, Cantidad = i.CantidadIngrediente });
                        });
                        context.SaveChanges();

                        var newProducto = new ProductoVenta();
                        context.ProductoVenta.Add(newProducto = new ProductoVenta()
                        {
                            CodigoReceta = newReceta.Clave,
                            PrecioVenta = producto.PrecioVenta,
                            PrecioCompra = producto.PrecioCompra,
                            Cantidad = 1,
                            Nombre = producto.Nombre,
                            Foto = producto.Foto,
                            Descripcion = producto.Descripcion,
                            Restricciones = producto.Restricciones,
                            Status = "Activo",
                            Registro = DateTime.Now
                        });
                        context.SaveChanges();

                        answer.Key = 1;
                        answer.Message = "Operación correcta";
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

        public AnswerMessage UpdateProducto(EProducto producto, EReceta receta)
        { 
            using (var context = new SAPContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Ingrediente.RemoveRange(context.Ingrediente.Where(x => x.ClaveReceta == producto.CodigoReceta));
                        context.SaveChanges();

                        var oldReceta = context.Receta.Where(r => r.Clave == producto.CodigoReceta).First();
                        oldReceta.Descripcion = receta.Descripcion;
                        context.SaveChanges();

                        receta.Ingredientes.ForEach(i =>
                        {
                            context.Ingrediente.Add(new Ingrediente() { ClaveReceta = producto.CodigoReceta, CodigoInsumo = i.CodigoInsumo, Cantidad = i.CantidadIngrediente });
                        });
                        context.SaveChanges();

                        var oldProducto = context.ProductoVenta.Where(p => p.Codigo == producto.Codigo).First();
                        oldProducto.Nombre = producto.Nombre;
                        oldProducto.PrecioVenta = producto.PrecioVenta;
                        oldProducto.Foto = producto.Foto;
                        oldProducto.PrecioCompra = producto.PrecioCompra;
                        oldProducto.Descripcion = producto.Descripcion;
                        oldProducto.Restricciones = producto.Restricciones;
                        context.SaveChanges();
                        transaction.Commit();

                        answer.Key = producto.Codigo;
                        answer.Message = "Operación correcta";
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
