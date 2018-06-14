using System;
using System.Collections.Generic;

namespace ShootingManager.Entities.Models
{
    public partial class BulletsCalibers
    {
        public int Id { get; set; }
        public int BulletId { get; set; }
        public int CaliberId { get; set; }
        public string Notes { get; set; }
        public virtual Bullet Bullet { get; set; }
        public virtual Caliber Caliber { get; set; }
    }
}
