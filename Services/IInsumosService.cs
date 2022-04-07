using Services.Model;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Services
{
    [ServiceContract]
    public interface IInsumosService
    {
        [OperationContract]
        List<EInsumo> GetInsumosList(string criterio, string valor, DateTime fecha, string status);
        [OperationContract]
        AnswerMessage AddInsumo(EInsumo insumo);
        [OperationContract]
        AnswerMessage UpdateInsumo(int oldInsumoID, EInsumo newInsumo);
        [OperationContract]
        AnswerMessage ChangeInsumoStatus(int insumoID, string status);
        [OperationContract]
        AnswerMessage ActualizarCantidades(List<EInsumo> nuevasCantidades);
        [OperationContract]
        bool IsDuplicated(string nombreActual, string nombreABuscar);
    }
}
