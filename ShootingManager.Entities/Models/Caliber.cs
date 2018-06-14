using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public partial class Caliber : Entity
    {
        public Caliber()
        {
            this.Brasses = new List<Brass>();
            this.CartridgeLoads = new List<CartridgeLoad>();
            this.Guns = new List<Gun>();
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
        public virtual ICollection<Brass> Brasses { get; set; }
        public virtual PrimerType PrimerType { get; set; }
        public virtual Unit DiameterUnit { get; set; }
        public virtual Unit BrassLengthUnit { get; set; }
        public virtual ICollection<CartridgeLoad> CartridgeLoads { get; set; }
        public virtual ICollection<Gun> Guns { get; set; }
        public virtual ICollection<GunsCalibers> GunsCalibers { get; set; }
        public virtual ICollection<CaliberCalibers> CaliberCalibers { get; set; }
    }
}
