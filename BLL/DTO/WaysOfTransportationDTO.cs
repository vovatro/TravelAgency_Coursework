using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BLL.DTO
{
    [DataContract]
    public class WaysOfTransportationDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string NameTransport { get; set; }
        [DataMember]
        public virtual IEnumerable<WaysInToursDTO> WaysInTours { get; set; }
    }
}