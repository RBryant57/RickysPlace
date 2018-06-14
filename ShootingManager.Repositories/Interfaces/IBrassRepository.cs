using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Repositories.Interfaces
{
    public interface IBrassRepository : IRepository<Brass>
    {
        List<BrassView> GetBrassViews();
        List<Caliber> GetCalibers();
        //List<Unit> GetLengthUnits();
        List<Manufacturer> GetManufacturers();
        List<Material> GetMaterials();
        List<Unit> GetQuantityUnits();
        List<IEntity> GetInventoryTypes();
    }
}