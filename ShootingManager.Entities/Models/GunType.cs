using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public partial class GunType : Entity
    {
        public GunType()
        {
            this.Guns = new List<Gun>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<Gun> Guns { get; set; }
    }
}
