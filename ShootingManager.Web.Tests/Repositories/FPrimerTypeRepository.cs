using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Web.Tests.Repositories
{
    public static class FPrimerTypeRepository
    {
        public static List<IEntity> AllPrimerTypes
        {
            get
            {
                var primerTypes = new List<IEntity>();
                var primerType = new PrimerType();

                primerType.Id = 1;
                primerType.Name = "Small Pistol";
                primerType.Abbreviation = "SP";
                primerTypes.Add(primerType);

                primerType = new PrimerType();
                primerType.Id = 2;
                primerType.Name = "Large Pistol";
                primerType.Abbreviation = "LP";
                primerTypes.Add(primerType);

                primerType = new PrimerType();
                primerType.Id = 3;
                primerType.Name = "Small Rifle";
                primerType.Abbreviation = "SR";
                primerTypes.Add(primerType);

                primerType = new PrimerType();
                primerType.Id = 4;
                primerType.Name = "Large Rifle";
                primerType.Abbreviation = "LR";
                primerTypes.Add(primerType);

                return primerTypes;
            }
        }
    }
}