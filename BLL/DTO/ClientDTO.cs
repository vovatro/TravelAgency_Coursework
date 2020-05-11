using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BLL.DTO
{
    [DataContract]
    public class ClientDTO
    {
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string SurName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }
        [DataMember]
        public DateTime DateOfBirth { get; set; }
        [DataMember]
        public UserDTO Usres { get; set; }
        [DataMember]
        public IEnumerable<ListClientShowInfoTourDTO> ListClientShowInfoTour { get; set; }
        [DataMember]
        public IEnumerable<ListOfTouristBuyDTO> ListOfTouristBuy { get; set; }
    }
}