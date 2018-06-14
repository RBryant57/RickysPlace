using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using local.yellowcaddis.ShootingManager.Core.Entities;

namespace local.yellowcaddis.ShootingManager.Web.Models
{
    public class ManufacturersListViewModel
    {
        public IEnumerable<Manufacturer> Manufacturers { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Notes { get; set; }
    }
}