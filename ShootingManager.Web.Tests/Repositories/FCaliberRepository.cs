using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Web.Tests.Repositories
{
    public static class FCaliberRepository
    {
        public static List<IEntity> AllCalibers
        {
            get
            {
                var calibers = new List<IEntity>();
                var caliber = new Caliber();

                caliber.Id = 1;
                caliber.Name = "Test Caliber";
                caliber.Diameter = 1;
                caliber.DiameterUnitId = 1;
                caliber.PrimerTypeId = 1;
                caliber.SortOrder = 1;
                calibers.Add(caliber);

                return calibers;
            }
        }
    }
}