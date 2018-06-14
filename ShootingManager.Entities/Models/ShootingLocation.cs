using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public partial class ShootingLocation : Entity
    {
        public ShootingLocation()
        {
            this.ShootingSessions = new List<ShootingSession>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<ShootingSession> ShootingSessions { get; set; }
    }
}
