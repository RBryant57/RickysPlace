using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Service.Interfaces
{
    public interface IBulletService : IDataService, IManagementService
    {
        List<BulletView> GetAllQuantityViewsWithNoInventory();
        List<BulletType> GetBulletTypes();
        List<BulletView> GetBulletViews();
        List<CartridgeLoad> GetCartridgeLoads();
        List<Unit> GetLengthUnits();
        List<Manufacturer> GetManufacturers();
        List<Unit> GetMassUnits();
        List<Material> GetMaterials();
        
    }
}