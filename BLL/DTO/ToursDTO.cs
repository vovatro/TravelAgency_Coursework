using DAL;
using System.Collections;
using System.Collections.Generic;
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
        public decimal Price { get; set; }
        [DataMember]
        public int MaxTourists { get; set; }
        [DataMember]
        public bool IsDeleted { get; set; }
        [DataMember]
        public virtual IEnumerable<ListClientShowInfoTourDTO> ListClientShowInfoTour { get; set; }
        [DataMember]
        public virtual IEnumerable<ListOfTouristBuyDTO> ListOfTouristBuy { get; set; }
        [DataMember]
        public virtual IEnumerable<PointInToursDTO> PointInTours { get; set; }
        [DataMember]
        public virtual IEnumerable<ResponsibleForTheToursDTO> ResponsibleForTheTours { get; set; }
        [DataMember]
        public virtual IEnumerable<WaysInToursDTO> WaysInTours { get; set; }
    }
}