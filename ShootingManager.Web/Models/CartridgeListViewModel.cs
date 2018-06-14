using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using local.yellowcaddis.ShootingManager.Core.Entities;

namespace local.yellowcaddis.ShootingManager.Web.Models
{
    public class CartridgeListViewModel
    {
        public IEnumerable<Cartridge> Cartridges { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public decimal diameter { get; set; }
        public string Notes { get; set; }
        public string Name { get; set; }
        public Brass Brass { get; set; }
        public Bullet Bullet { get; set; }
    }
}