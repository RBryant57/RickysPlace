using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using local.yellowcaddis.ShootingManager.Core.Entities;

namespace local.yellowcaddis.ShootingManager.Web.Models
{
    public class BrassListViewModel
    {
        public IEnumerable<Brass> Brass { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public Caliber Caliber { get; set; }
        public string Notes { get; set; }
    }
}