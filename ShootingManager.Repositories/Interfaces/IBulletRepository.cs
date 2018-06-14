using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Repositories.Interfaces
{
    public interface IBulletRepository : IRepository<Bullet>
    {
        List<BulletType> GetBulletTypes();
        List<BulletView> GetBulletViews();
        List<Unit> GetLengthUnits();
        List<Manufacturer> GetManufacturers();
        List<Unit> GetMassUnits();
        List<Material> GetMaterials();
        List<Unit> GetQuantityUnits();
        List<IEntity> GetInventoryTypes();
    }
}