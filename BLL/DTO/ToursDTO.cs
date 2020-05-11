using DAL;
using System.Runtime.Serialization;

namespace BLL.DTO
{
    [DataContract]
    public class ToursDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string TourName { get; set; }
        [DataMember]
        public System.DateTime StartDate { get; set; }
        [DataMember]
        public System.DateTime EndDate { get; set; }
        [DataMember]
        public int Price { get; set; }
        [DataMember]
        public int MaxTourists { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
    }
}