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
    public interface IProductosService
    {
        [OperationContract]
        List<EProducto> GetProductosList(string criterio, string valor, DateTime fecha, string status);
        [OperationContract]
        EReceta GetReceta(int clave);
        [OperationContract]
        List<EInsumo> GetIngredientes();
        [OperationContract]
        AnswerMessage AddProducto(EProducto producto, EReceta receta);
        [OperationContract]
        bool IsDuplicated(string nombreActual, string nombreABuscar);
        [OperationContract]
        AnswerMessage UpdateProducto(EProducto producto, EReceta receta);
        [OperationContract]
        AnswerMessage ChangeProductoStatus(int productoID, string status);
        [OperationContract]
        string CheckIngredientesStatus(List<EIngrediente> ingredientes);
    }
}
