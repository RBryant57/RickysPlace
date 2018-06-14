using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Web.Tests.Repositories
{
    public static class FUnitTypeRepository
    {
        public static List<IEntity> AllUnitTypes
        {
            get
            {
                var unitTypes = new List<IEntity>();
                var unitType = new UnitType();

                unitType.Id = 1;
                unitType.Name = "Length";
                unitTypes.Add(unitType);

                unitType = new UnitType();
                unitType.Id = 2;
                unitType.Name = "Mass";
                unitTypes.Add(unitType);

                unitType = new UnitType();
                unitType.Id = 3;
                unitType.Name = "Velocity";
                unitTypes.Add(unitType);

                unitType = new UnitType();
                unitType.Id = 4;
                unitType.Name = "Pressure";
                unitTypes.Add(unitType);

                return unitTypes;
            }
        }
    }
}