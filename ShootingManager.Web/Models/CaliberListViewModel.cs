using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using local.yellowcaddis.ShootingManager.Core.Entities;

namespace local.yellowcaddis.ShootingManager.Web.Models
{
    public class CaliberListViewModel
    {
        public IEnumerable<Caliber> Calibers { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public decimal diameter { get; set; }
        public string Notes { get; set; }
        public string Name { get; set; }
    }
}