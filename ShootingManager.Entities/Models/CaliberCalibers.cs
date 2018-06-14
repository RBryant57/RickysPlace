using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingManager.Entities.Models
{
    public class CaliberCalibers : Entity
    {
        public int Id { get; set; }
        public int PrimaryCaliberId { get; set; }
        public int SecondaryCaliberId { get; set; }
        public string Notes { get; set; }
        public virtual Caliber Caliber { get; set; }
        public virtual Caliber CaliberSecondary { get; set; }
    }

    public class GunsCalibers : Entity
    {
        public int GunId { get; set; }
        public int CaliberId { get; set; }
        public virtual Caliber Caliber { get; set; }
        public virtual Gun Gun { get; set; }
    }
}
