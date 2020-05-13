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
        public int Id { get; set; }
        [DataMember]
        public string CountryName { get; set; }
        [DataMember]
        public IEnumerable<CityDTO> City { get; set; }
    }
}