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
        public AgensyWorcerDTO AgensyWorcer { get; set; }
        [DataMember]
        public ToursDTO Tours { get; set; }
    }
}