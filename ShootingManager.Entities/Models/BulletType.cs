using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public partial class BulletType : Entity
    {
        public BulletType()
        {
            this.Bullets = new List<Bullet>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<Bullet> Bullets { get; set; }
    }
}
