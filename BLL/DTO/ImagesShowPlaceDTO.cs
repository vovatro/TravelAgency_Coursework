using System.Runtime.Serialization;

namespace BLL.DTO
{
    [DataContract]
    public class ImagesShowPlaceDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ImageURL { get; set; }
        [DataMember]
        public int ShowPlaceId { get; set; }
        [DataMember]
        public ShowPlaceDTO ShowPlace { get; set; }
    }
}