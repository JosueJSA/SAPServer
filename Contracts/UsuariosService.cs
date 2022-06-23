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
    public class UsuariosService : IUsuariosService
    {

        private ObjectParameter key = new ObjectParameter("Key", typeof(int));
        private ObjectParameter message = new ObjectParameter("Message", typeof(string));
        private AnswerMessage answer = new AnswerMessage();

        public AnswerMessage AddUsuario(EUsuario usuario)
        {
            using (var context = new SAPContext())
            {
                context.SPIUsuario(usuario.Email, usuario.Password, usuario.Nombre, 
                    usuario.Apellidos, usuario.TipoUsuario, usuario.CodigoPostal, 
                    usuario.Status, usuario.Salario, usuario.Telefono, usuario.Ciudad, key, message);
                context.SaveChanges();
                answer.Key = Convert.ToInt32(key.Value);
                answer.Message = Convert.ToString(message.Value);
                return answer;
            }
        }

        public AnswerMessage ChangeStatusUsuario(int usaurioID, string status)
        {
            using (var context = new SAPContext())
            {
                context.SPChangeStatusUsuario(usaurioID, status, key, message);
                answer.Key = Convert.ToInt32(key.Value);
                answer.Message = Convert.ToString(message.Value);
                return answer;
            }
        }

        public EUsuario GetUsuarioByEmail(string email, string password)
        {
            using (var context = new SAPContext())
            {
                try
                {
                    return context.SPGUsuarioEmail(email, password).First();
                }catch (Exception)
                {
                    return null;
                }
            }
        }

        public List<EUsuario> GetUsuarios(string status, string nombre = null)
        {
            using (var context = new SAPContext())
            {
                if (nombre == null)
                    return context.SPGUsuario(null, status).ToList();
                else
                    return context.SPGUsuario($"%{nombre}%", status).ToList();
            }
        }

        public AnswerMessage UpdateUsuario(EUsuario usuario)
        {
            using (var context = new SAPContext())
            {
                context.SPUUsuario(usuario.Clave, usuario.Email, usuario.Password, usuario.Nombre,
                    usuario.Apellidos, usuario.TipoUsuario, usuario.CodigoPostal,
                    usuario.Status, usuario.Salario, usuario.Telefono, usuario.Ciudad, key, message);
                context.SaveChanges();
                answer.Key = Convert.ToInt32(key.Value);
                answer.Message = Convert.ToString(message.Value);
                return answer;
            }
        }
    }
}
