using System.Runtime.Serialization;

namespace BLL.DTO
{
    [DataContract]
    public class ListOfTouristBuyDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int ToursId { get; set; }
        [DataMember]
        public PersonDTO Person { get; set; }
        [DataMember]
        public ToursDTO Tours { get; set; }
    }
}