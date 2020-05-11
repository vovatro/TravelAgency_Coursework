using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BLL.DTO
{
    [DataContract]
    public class CountryDTO
    {
        [DataMember]
        public string CountryName { get; set; }
        [DataMember]
        public IEnumerable<CityDTO> City { get; set; }
    }
}