using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Service.Interfaces
{
    public interface IBulletQuantityService : IDataService
    {
        List<Bullet> GetBullets();
        List<BulletView> GetBulletViews();
        List<Bullet> GetBulletsWithNoInventory();
        List<BulletView> GetBulletViewsWithNoInventory();
        List<InventoryType> GetInventoryTypes();
        List<Unit> GetQuantityUnits();
        List<UnitView> GetQuantityUnitViews();
        int GetQuantity(int entityId);
    }
}