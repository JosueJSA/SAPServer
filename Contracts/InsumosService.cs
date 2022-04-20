using Services;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading;

namespace Contracts
{
    internal class InsumosService : IInsumosService
    {
        private ObjectParameter key = new ObjectParameter("Key", typeof(int));
        private ObjectParameter message = new ObjectParameter("Message", typeof(string));
        private AnswerMessage answer = new AnswerMessage();

        public AnswerMessage ActualizarCantidades(List<EInsumo> nuevasCantidades)
        {
            answer.Key = -1;
            using (var context = new SAPContext())
            {
                foreach (var insumo in nuevasCantidades)
                {
                    var result = context.Insumo.Where(item => item.Codigo == insumo.Codigo).ToList().First();
                    if (result != null)
                        result.Cantidad = insumo.Cantidad;
                }
                context.SaveChanges();
                answer.Key = 1;
            }
            return answer;
        }

        public AnswerMessage AddInsumo(EInsumo insumo)
        {
            using (var context = new SAPContext())
            {
                context.SPIInsumo(insumo.PrecioCompra, insumo.Cantidad, insumo.Nombre, insumo.Descripcion, insumo.Restricciones, insumo.UnidadMedida, insumo.ProveedorDeInsumo, key, message);
                answer.Key = Convert.ToInt32(key.Value);
                answer.Message = Convert.ToString(message.Value);
            }
            return answer;
        }

        public AnswerMessage ChangeInsumoStatus(int insumoID, string status)
        {
            using (var context = new SAPContext())
            {
                context.SPChangeStatusInsumo(insumoID, status, key, message);
                answer.Key = Convert.ToInt32(key.Value);
                answer.Message = Convert.ToString(message.Value);
            }
            return answer;
        }

        public List<EInsumo> GetInsumosList(string criterio, string valor, DateTime fecha, string status)
        {
            List<EInsumo> insumosList = null;
            using (var context = new SAPContext())
            {
                insumosList = context.SPGInsumos(criterio, valor, fecha, status).ToList();
            }
            return insumosList;
        }

        public bool IsDuplicated(string nombreActual, string nombreABuscar)
        {
            bool returnValue = false;
            using (var context = new SAPContext())
            {
                if (nombreActual.ToLower() != nombreABuscar.ToLower() && context.Insumo.Any(insumo => insumo.Nombre.ToLower() == nombreABuscar.ToLower()))
                    returnValue = true;
            }
            return returnValue;
        }

        public bool IsUsedInReceta(int codigoInsumo)
        {
            bool returnValue = false;
            using (var context = new SAPContext())
            {
                var result = context.Ingredientes.Where(i => i.CodigoInsumo == codigoInsumo);
                if (result != null && result.ToList().Count > 0)
                    returnValue = true;
            }
            return returnValue;
        }

        public AnswerMessage UpdateInsumo(int oldInsumoID, EInsumo newInsumo)
        {
            using (var context = new SAPContext())
            {
                context.SPUInsumo(oldInsumoID, newInsumo.PrecioCompra, newInsumo.Cantidad, newInsumo.Nombre, newInsumo.Descripcion, newInsumo.Restricciones, newInsumo.UnidadMedida, newInsumo.ProveedorDeInsumo, key, message);
                answer.Key = Convert.ToInt32(key.Value);
                answer.Message = Convert.ToString(message.Value);
            }
            return answer;
        }
    }
}
