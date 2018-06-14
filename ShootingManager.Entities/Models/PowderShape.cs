using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public partial class PowderShape : Entity
    {
        public PowderShape()
        {
            this.Powders = new List<Powder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<Powder> Powders { get; set; }
    }
}
