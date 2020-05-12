using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BLL.DTO
{
    [DataContract]
    public class PersonDTO
    {
        [DataMember]
        public int Id { get; set; }
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
        public System.DateTime DateOfCreateAccount { get; set; }
        [DataMember]
        public System.DateTime DateOfBirth { get; set; }
        [DataMember]
        public string PersonStatus { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public IEnumerable<ListClientShowInfoTourDTO> ListClientShowInfoTour { get; set; }
        [DataMember]
        public IEnumerable<ListOfTouristBuyDTO> ListOfTouristBuy { get; set; }
        [DataMember]
        public IEnumerable<ResponsibleForTheToursDTO> ResponsibleForTheTours { get; set; }
    }
}