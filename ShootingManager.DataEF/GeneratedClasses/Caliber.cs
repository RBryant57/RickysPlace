//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShootingManager.DataEF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Caliber
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Caliber()
        {
            this.Brasses = new HashSet<Brass>();
            this.CartridgeLoads = new HashSet<CartridgeLoad>();
            this.Guns = new HashSet<Gun>();
            this.GunsCalibers = new HashSet<GunsCaliber>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Diameter { get; set; }
        public int DiameterUnitId { get; set; }
        public decimal BrassLength { get; set; }
        public int BrassLengthUnitId { get; set; }
        public int PrimerTypeId { get; set; }
        public int SortOrder { get; set; }
        public string Notes { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Brass> Brasses { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual Unit Unit1 { get; set; }
        public virtual PrimerType PrimerType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartridgeLoad> CartridgeLoads { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Gun> Guns { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GunsCaliber> GunsCalibers { get; set; }
    }
}
