using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Web.ViewModels
{
    public class PrimerViewModel
    {
        public IEntity Entity { get; set; }
        public PrimerView EntityView { get; set; }
        public PrimerQuantity EntityQuantity { get; set; }
    }
}