using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Web.ViewModels
{
    public class GunViewModel
    {
        public IEntity Entity { get; set; }
        public GunView EntityView { get; set; }
        public bool CanDelete { get; set; }

    }
}
