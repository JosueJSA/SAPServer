using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Services.Model
{
    [DataContract]
    public class AnswerMessage
    {
        [DataMember]
        public int Key { get; set; }
        [DataMember]
        public string Message { get; set; } 
    }
}
