using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BLL.DTO
{
    [DataContract]
    public class ShowPlaceDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ShowPlaceName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public int CityId { get; set; }
        [DataMember]
        public CityDTO City { get; set; }
        [DataMember]
        public IEnumerable<ImagesShowPlaceDTO> ImagesShowPlace { get; set; }
        [DataMember]
        public IEnumerable<PointInToursDTO> PointInTours { get; set; }
    }
}