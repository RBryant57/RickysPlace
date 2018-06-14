using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Web.ViewModels
{
    public class PowderViewModel
    {
        public IEntity Entity { get; set; }
        public PowderView EntityView { get; set; }
        public bool CanDelete { get; set; }
        public PowderQuantity EntityQuantity { get; set; }
        public decimal EntityQuantityAmount { get; set; }
    }
}