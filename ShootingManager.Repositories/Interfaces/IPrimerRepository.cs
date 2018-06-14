using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Repositories.Interfaces
{
    public interface IPrimerRepository : IRepository<Primer>
    {
        List<PrimerType> GetPrimerTypes();
        List<PrimerView> GetPrimerViews();
        List<Manufacturer> GetManufacturers();
        List<Unit> GetQuantityUnits();
        List<IEntity> GetInventoryTypes();

    }
}