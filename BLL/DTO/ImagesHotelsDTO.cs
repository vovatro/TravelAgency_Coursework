using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BLL.DTO
{
    [DataContract]
    public class ImagesHotelsDTO
    {
        [DataMember]
        public string ImageURL { get; set; }
        [DataMember]
        public HotelsDTO Hotels { get; set; }
    }
}