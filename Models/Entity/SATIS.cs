//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcOtomasyon.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class SATIS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SATIS()
        {
            this.SATISDETAY = new HashSet<SATISDETAY>();
        }
    
        public int SATISID { get; set; }
        public Nullable<decimal> TOPLAMTUTAR { get; set; }
        public Nullable<System.DateTime> SATISTARIH { get; set; }
        public Nullable<int> MUSTERIID { get; set; }
    
        public virtual MUSTERILER MUSTERILER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SATISDETAY> SATISDETAY { get; set; }
    }
}
