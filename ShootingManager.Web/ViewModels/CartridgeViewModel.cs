using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Web.ViewModels
{
    public class CartridgeViewModel
    {
        public IEntity Entity { get; set; }
        public CartridgeView EntityView { get; set; }
        public CartridgeQuantity EntityQuantity { get; set; }
    }
}