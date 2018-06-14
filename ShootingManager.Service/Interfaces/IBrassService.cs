using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Service.Interfaces
{
    public interface IBrassService : IDataService, IManagementService
    {
        List<BrassView> GetAllQuantityViewsWithNoInventory();
        List<BrassView> GetBrassViews();
        List<Caliber> GetCalibers();
        List<Cartridge> GetCartridges();
        //List<Unit> GetLengthUnits();
        List<Manufacturer> GetManufacturers();
        List<Material> GetMaterials();
        int Clone(int id);

    }
}