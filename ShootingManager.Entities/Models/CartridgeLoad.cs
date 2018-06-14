using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public partial class CartridgeLoad : Entity
    {
        public CartridgeLoad()
        {
            this.Cartridges = new List<Cartridge>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CaliberId { get; set; }
        public int BulletId { get; set; }
        public int? PowderId { get; set; }
        public decimal? PowderWeight { get; set; }
        public int? PowderWeightUnitId { get; set; }
        public decimal COL { get; set; }
        public int COLUnitId { get; set; }
        public int? Velocity { get; set; }
        public int? VelocityUnitId { get; set; }
        public int? Pressure { get; set; }
        public int? PressureUnitId { get; set; }
        public string Notes { get; set; }
        public virtual Bullet Bullet { get; set; }
        public virtual Caliber Caliber { get; set; }
        public virtual ICollection<Cartridge> Cartridges { get; set; }
        public virtual Powder Powder { get; set; }
        public virtual Unit PowderWeightUnit { get; set; }
        public virtual Unit COLUnit { get; set; }
        public virtual Unit VelocityUnit { get; set; }
        public virtual Unit PressureUnit { get; set; }
    }
}
