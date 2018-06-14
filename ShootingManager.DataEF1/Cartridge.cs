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
    
    public partial class Cartridge
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cartridge()
        {
            this.CartridgeCosts = new HashSet<CartridgeCost>();
            this.CartridgeQuantities = new HashSet<CartridgeQuantity>();
            this.ShootingSessions = new HashSet<ShootingSession>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int CartridgeLoadId { get; set; }
        public int BrassId { get; set; }
        public Nullable<int> PrimerId { get; set; }
        public int ManufacturerId { get; set; }
        public string Notes { get; set; }
    
        public virtual Brass Brass { get; set; }
        public virtual CartridgeLoad CartridgeLoad { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Primer Primer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartridgeCost> CartridgeCosts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CartridgeQuantity> CartridgeQuantities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShootingSession> ShootingSessions { get; set; }
    }
}
