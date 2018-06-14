using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;
using ShootingManager.Repositories.Interfaces;

namespace ShootingManager.Web.Tests.Repositories
{
    public static class FBrassRepository
    {
        public static List<IEntity> AllBrasses
        {
            get
            {
                var brasses = new List<IEntity>();
                var brass = new Brass();
                brass.Id = 1;
                brass.Name = "Standard Test";
                brass.CaliberId = 1;
                brass.Length = 1;
                brass.LengthUnitId = 1;
                brass.ManufacturerId = 1;
                brass.TimesFired = 1;
                brasses.Add(brass);

                return brasses;
            }
        }
    }
}
