//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.TAContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class WaysInTours
    {
        public int Id { get; set; }
        public Nullable<int> ToursId { get; set; }
        public Nullable<int> StartCityId { get; set; }
        public Nullable<int> EndCityId { get; set; }
        public Nullable<int> WaysOfTransportationId { get; set; }
    
        public virtual City City { get; set; }
        public virtual City City1 { get; set; }
        public virtual Tours Tours { get; set; }
        public virtual WaysOfTransportation WaysOfTransportation { get; set; }
    }
}