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
    public interface IUsuariosService
    {
        [OperationContract]
        List<EUsuario> GetUsuarios(string status, string nombre);

        [OperationContract]
        AnswerMessage AddUsuario(EUsuario usuario);

        [OperationContract]
        AnswerMessage UpdateUsuario(EUsuario usuario);

        [OperationContract]
        EUsuario GetUsuarioByEmail(string email, string password);

        [OperationContract]
        AnswerMessage ChangeStatusUsuario(int usaurioID, string status);

    }
}
