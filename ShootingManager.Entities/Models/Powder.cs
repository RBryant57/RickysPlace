using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public partial class Powder : Entity
    {
        public Powder()
        {
            this.CartridgeLoads = new List<CartridgeLoad>();
            this.PowderCosts = new List<PowderCost>();
            this.PowderQuantities = new List<PowderQuantity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        public int PowderTypeId { get; set; }
        public int PowderShapeId { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<CartridgeLoad> CartridgeLoads { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual PowderShape PowderShape { get; set; }
        public virtual PowderType PowderType { get; set; }
        public virtual ICollection<PowderCost> PowderCosts { get; set; }
        public virtual ICollection<PowderQuantity> PowderQuantities { get; set; }
    }
}
