using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public partial class UnitType : Entity
    {
        public UnitType()
        {
            this.Units = new List<Unit>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}
