using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Repositories.Interfaces
{
    public interface IPowderRepository : IRepository<Powder>
    {
        List<Manufacturer> GetManufacturers();
        List<Unit> GetMassUnits();
        List<PowderShape> GetPowderShapes();
        List<PowderType> GetPowderTypes();        
        List<PowderView> GetPowderViews();
        List<Unit> GetQuantityUnits();
        List<IEntity> GetInventoryTypes();
    }
}