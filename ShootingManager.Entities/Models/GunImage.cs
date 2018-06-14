using System;
using System.Collections.Generic;

namespace ShootingManager.Entities.Models
{
    public partial class GunImage
    {
        public int Id { get; set; }
        public int GunId { get; set; }
        public string PictureLocation { get; set; }
        public virtual Gun Gun { get; set; }
    }
}
