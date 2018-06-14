using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Web.Tests.Repositories
{
    public static class FUnitRepository
    {
        public static List<IEntity> AllUnits
        {
            get
            {
                var units = new List<IEntity>();
                var unit = new Unit();

                unit.Id = 1;
                unit.Name = "Inch";
                unit.Plural = "Inches";
                unit.Abbreviation = "in.";
                unit.UnitTypeId = 1;
                units.Add(unit);

                unit = new Unit();
                unit.Id = 2;
                unit.Name = "Grain";
                unit.Plural = "Grains";
                unit.Abbreviation = "gr.";
                unit.UnitTypeId = 2;
                units.Add(unit);

                unit = new Unit();
                unit.Id = 3;
                unit.Name = "Feet Per Second";
                unit.Plural = "Feet Per Second";
                unit.Abbreviation = "fps.";
                unit.UnitTypeId = 3;
                units.Add(unit);

                unit = new Unit();
                unit.Id = 4;
                unit.Name = "Pounds Per Square Inch";
                unit.Plural = "Pounds Per Square Inch";
                unit.Abbreviation = "psi.";
                unit.UnitTypeId = 4;
                units.Add(unit);

                return units;
            }
        }
    }
}