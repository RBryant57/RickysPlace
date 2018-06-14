using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public partial class Cartridge : Entity
    {
        public Cartridge()
        {
            this.CartridgeQuantities = new List<CartridgeQuantity>();
            this.ShootingSessions = new List<ShootingSession>();
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
        public virtual ICollection<CartridgeQuantity> CartridgeQuantities { get; set; }
        public virtual ICollection<CartridgeCost> CartridgeCosts { get; set; }
        public virtual ICollection<ShootingSession> ShootingSessions { get; set; }
    }
}
