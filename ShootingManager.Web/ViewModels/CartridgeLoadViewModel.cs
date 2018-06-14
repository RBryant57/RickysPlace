using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Web.ViewModels
{
    public class CartridgeLoadViewModel
    {
        public IEntity Entity { get; set; }
        public CartridgeLoadView EntityView { get; set; }
    }
}