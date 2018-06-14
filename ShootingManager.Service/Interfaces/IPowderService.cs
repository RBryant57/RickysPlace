using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Service.Interfaces
{
    public interface IPowderService : IDataService, IManagementService
    {
        List<Manufacturer> GetManufacturers();
        List<PowderType> GetPowderTypes();
        List<PowderShape> GetPowderShapes();
        List<PowderView> GetPowderViews();
        List<CartridgeLoad> GetCartridgeLoads();
        List<PowderView> GetAllQuantityViewsWithNoInventory();
    }
}