using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public partial class Gun : Entity
    {
        public Gun()
        {
            this.GunImages = new List<GunImage>();
            this.ShootingSessions = new List<ShootingSession>();
        }

        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public int CaliberId { get; set; }
        public int SellerId { get; set; }
        public int? BuyerId { get; set; }
        public int ManufacturerId { get; set; }
        public int Capacity { get; set; }
        public decimal BarrelLength { get; set; }
        public int BarrelLengthUnitId { get; set; }
        public int GunTypeId { get; set; }
        public decimal Cost { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public DateTime? RetireDate { get; set; }
        public string Details { get; set; }
        public string Notes { get; set; }
        public virtual Caliber Caliber { get; set; }
        public virtual GunType GunType { get; set; }
        public virtual Unit BarrelLengthUnit { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Manufacturer Seller { get; set; }
        public virtual Manufacturer Buyer { get; set; }
        public virtual ICollection<GunImage> GunImages { get; set; }
        public virtual ICollection<ShootingSession> ShootingSessions { get; set; }
        public virtual ICollection<GunsCalibers> GunsCalibers { get; set; }
        public virtual ICollection<CaliberCalibers> CaliberCalibers { get; set; }
    }
}
