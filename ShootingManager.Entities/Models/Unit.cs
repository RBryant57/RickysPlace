using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public partial class Unit : Entity
    {
        public Unit()
        {
            this.Brasses = new List<Brass>();
            this.BrassCosts = new List<BrassCost>();
            this.BrassQuantities = new List<BrassQuantity>();
            this.DiameterUnitBullets = new List<Bullet>();
            this.LengthUnitBullets = new List<Bullet>();
            this.MassUnitBullets = new List<Bullet>();
            this.BulletCosts = new List<BulletCost>();
            this.BulletQuantities = new List<BulletQuantity>();
            this.Calibers = new List<Caliber>();
            this.PowderWeightUnitCartridgeLoads = new List<CartridgeLoad>();
            this.COLUnitCartridgeLoads = new List<CartridgeLoad>();
            this.VelocityUnitCartridgeLoads = new List<CartridgeLoad>();
            this.PressureUnitCartridgeLoads = new List<CartridgeLoad>();
            this.CartridgeQuantities = new List<CartridgeQuantity>();
            this.CartridgeCosts = new List<CartridgeCost>();
            this.PowderCosts = new List<PowderCost>();
            this.PowderQuantities = new List<PowderQuantity>();
            this.PrimerCosts = new List<PrimerCost>();
            this.PrimerQuantities = new List<PrimerQuantity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Plural { get; set; }
        public string Abbreviation { get; set; }
        public int UnitTypeId { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<Brass> Brasses { get; set; }
        public virtual ICollection<BrassCost> BrassCosts { get; set; }
        public virtual ICollection<BrassQuantity> BrassQuantities { get; set; }
        public virtual ICollection<Caliber> DiameterUnitCalibers { get; set; }
        public virtual ICollection<Caliber> BrassLengthUnitCalibers { get; set; }
        public virtual ICollection<Bullet> DiameterUnitBullets { get; set; }
        public virtual ICollection<Bullet> LengthUnitBullets { get; set; }
        public virtual ICollection<Bullet> MassUnitBullets { get; set; }
        public virtual ICollection<BulletCost> BulletCosts { get; set; }
        public virtual ICollection<BulletQuantity> BulletQuantities { get; set; }
        public virtual ICollection<Caliber> Calibers { get; set; }
        public virtual ICollection<CartridgeLoad> PowderWeightUnitCartridgeLoads { get; set; }
        public virtual ICollection<CartridgeLoad> COLUnitCartridgeLoads { get; set; }
        public virtual ICollection<CartridgeLoad> VelocityUnitCartridgeLoads { get; set; }
        public virtual ICollection<CartridgeLoad> PressureUnitCartridgeLoads { get; set; }
        public virtual ICollection<CartridgeQuantity> CartridgeQuantities { get; set; }
        public virtual ICollection<CartridgeCost> CartridgeCosts { get; set; }
        public virtual ICollection<PowderCost> PowderCosts { get; set; }
        public virtual ICollection<PowderQuantity> PowderQuantities { get; set; }
        public virtual ICollection<PrimerCost> PrimerCosts { get; set; }
        public virtual ICollection<PrimerQuantity> PrimerQuantities { get; set; }
        public virtual ICollection<Gun> Guns { get; set; }
        public virtual UnitType UnitType { get; set; }
    }
}
