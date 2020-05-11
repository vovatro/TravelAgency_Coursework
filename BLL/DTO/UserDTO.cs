using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BLL.DTO
{
    [DataContract]
    public class UserDTO
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string UserStatus { get; set; }
        //[DataMember]
        //public IEnumerable<AgensyWorcerDTO> AgensyWorcer { get; set; }
        //[DataMember]
        //public IEnumerable<ClientDTO> Client { get; set; }
    }
}