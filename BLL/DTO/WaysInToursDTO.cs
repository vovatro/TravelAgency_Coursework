using System.Runtime.Serialization;

namespace BLL.DTO
{
    [DataContract]
    public class WaysInToursDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ToursId { get; set; }
        [DataMember]
        public int StartCityId { get; set; }
        [DataMember]
        public int EndCityId { get; set; }
        [DataMember]
        public int WaysOfTransportationId { get; set; }
        [DataMember]

        public CityDTO City { get; set; }
        [DataMember]
        public CityDTO City1 { get; set; }
        [DataMember]
        public ToursDTO Tours { get; set; }
        [DataMember]
        public WaysOfTransportationDTO WaysOfTransportation { get; set; }
    }
}