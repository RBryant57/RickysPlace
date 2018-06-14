using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public class Brass : Entity
    {
        public Brass()
        {
            this.BrassCosts = new List<BrassCost>();
            this.BrassQuantities = new List<BrassQuantity>();
            this.Cartridges = new List<Cartridge>();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public int CaliberId { get; set; }
        //public decimal Length { get; set; }
        //public int LengthUnitId { get; set; }
        public int MaterialId { get; set; }
        public int ManufacturerId { get; set; }
        public int TimesFired { get; set; }
        public string Notes { get; set; }
        public virtual Caliber Caliber { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Material Material { get; set; }
        public virtual Unit LengthUnit { get; set; }
        public virtual ICollection<BrassCost> BrassCosts { get; set; }
        public virtual ICollection<BrassQuantity> BrassQuantities { get; set; }
        public virtual ICollection<Cartridge> Cartridges { get; set; }
    }
}
