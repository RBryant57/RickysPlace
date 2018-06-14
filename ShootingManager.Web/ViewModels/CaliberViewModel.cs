using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Web.ViewModels
{
    public class CaliberViewModel
    {
        public IEntity Entity { get; set; }
        public CaliberView EntityView { get; set; }
        public bool CanDelete { get; set; }

    }
}
