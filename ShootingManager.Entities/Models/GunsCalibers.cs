using Data.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingManager.Entities.Models
{
    public class GunsCalibers : IEntity
    {
        public int Id { get; set; }

        public int GunId { get; set; }

        public int CaliberId { get; set; }

        public virtual Caliber Caliber { get; set; }

        public virtual Gun Gun { get; set; }

        public void Dispose() { }
    }
}
