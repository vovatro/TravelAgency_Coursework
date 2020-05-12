using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BLL.DTO
{
    [DataContract]
    public class ResponsibleForTheToursDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ToursId { get; set; }
        [DataMember]
        public int AgencyWorkerId { get; set; }
        [DataMember]
        public PersonDTO Person { get; set; }
        [DataMember]
        public ToursDTO Tours { get; set; }
    }
}