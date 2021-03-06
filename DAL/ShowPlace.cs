//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using DAL.Interfaces;
    using System;
    using System.Collections.Generic;
    
    public partial class ShowPlace : IReturnId
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShowPlace()
        {
            this.ImagesShowPlace = new HashSet<ImagesShowPlace>();
            this.PointInTours = new HashSet<PointInTours>();
        }
    
        public int Id { get; set; }
        public string ShowPlaceName { get; set; }
        public decimal Price { get; set; }
        public Nullable<int> CityId { get; set; }
    
        public virtual City City { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImagesShowPlace> ImagesShowPlace { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PointInTours> PointInTours { get; set; }

        public int GetId()
        {
            return Id;
        }
    }
}
