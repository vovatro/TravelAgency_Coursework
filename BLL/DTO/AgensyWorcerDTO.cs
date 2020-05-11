using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BLL.DTO
{
    [DataContract]
    public class AgensyWorcerDTO
    {
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string SurName { get; set; }
        [DataMember]
        public string Position { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public DateTime DateOfRecruitment { get; set; }
        [DataMember]
        public UserDTO Usres { get; set; }
        [DataMember]
        public ICollection<ResponsibleForTheToursDTO> ResponsibleForTheTours { get; set; }
    }
}