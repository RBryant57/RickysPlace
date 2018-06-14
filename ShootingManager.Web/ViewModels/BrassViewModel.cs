using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Web.ViewModels
{
    public class BrassViewModel
    {
        public IEntity Entity { get; set; }
        public BrassView EntityView { get; set; }
        public bool CanDelete { get; set; }
        public BrassQuantity EntityQuantity { get; set; }
    }
}