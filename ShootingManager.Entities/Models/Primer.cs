using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public partial class Primer : Entity
    {
        public Primer()
        {
            this.Cartridges = new List<Cartridge>();
            this.PrimerCosts = new List<PrimerCost>();
            this.PrimerQuantities = new List<PrimerQuantity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int PrimerTypeId { get; set; }
        public int ManufacturerId { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<Cartridge> Cartridges { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual PrimerType PrimerType { get; set; }
        public virtual ICollection<PrimerCost> PrimerCosts { get; set; }
        public virtual ICollection<PrimerQuantity> PrimerQuantities { get; set; }
    }
}
