using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public partial class ShootingSession : Entity
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int LocationId { get; set; }
        public int GunId { get; set; }
        public int CartridgeId { get; set; }
        public int Rounds { get; set; }
        public int? Retention { get; set; }
        public string Notes { get; set; }
        public virtual Cartridge Cartridge { get; set; }
        public virtual Gun Gun { get; set; }
        public virtual ShootingLocation ShootingLocation { get; set; }
    }
}
