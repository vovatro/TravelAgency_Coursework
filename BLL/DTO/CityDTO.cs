using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BLL.DTO
{
    [DataContract]
    public class CityDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CityName { get; set; }
        [DataMember]
        public CountryDTO Country { get; set; }
        [DataMember]
        public IEnumerable<HotelsDTO> Hotels { get; set; }
        [DataMember]
        public IEnumerable<ShowPlaceDTO> ShowPlace { get; set; }
        [DataMember]
        public IEnumerable<WaysInToursDTO> WaysInTours { get; set; }
        [DataMember]
        public IEnumerable<WaysInToursDTO> WaysInTours1 { get; set; }
    }
}