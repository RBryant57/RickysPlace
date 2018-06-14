using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Web.ViewModels
{
    public class BulletViewModel
    {
        public IEntity Entity { get; set; }
        public BulletView EntityView { get; set; }
        public bool CanDelete { get; set; }
        public BulletQuantity EntityQuantity { get; set; }
    }
}