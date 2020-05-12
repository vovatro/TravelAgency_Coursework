using System.Runtime.Serialization;

namespace BLL.DTO
{
    [DataContract]
    public class PointInToursDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ShowPlaceId { get; set; }
        [DataMember]
        public int ToursId { get; set; }
        [DataMember]
        public System.DateTime DateOfVisit { get; set; }
        [DataMember]
        public bool IsPriceInTours { get; set; }
        [DataMember]
        public ShowPlaceDTO ShowPlace { get; set; }
        [DataMember]
        public ToursDTO Tours { get; set; }
    }
}