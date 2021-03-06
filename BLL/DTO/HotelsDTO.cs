﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BLL.DTO
{
    [DataContract]
    public class HotelsDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string HotelsName { get; set; }
        [DataMember]
        public int CityId { get; set; }
        [DataMember]
        public decimal PriceDay { get; set; }
        [DataMember]
        public int Stars { get; set; }
        [DataMember]
        public CityDTO City { get; set; }
        [DataMember]
        public IEnumerable<ImagesHotelsDTO> ImagesHotels { get; set; }
    }
}