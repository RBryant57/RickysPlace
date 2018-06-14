using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Service.Interfaces
{
    public interface ICartridgeService : IDataService, IManagementService
    {
        List<CartridgeView> GetCartridgeViews();
        List<CartridgeLoad> GetCartridgeLoads();
        List<CartridgeLoadView> GetCartridgeLoadViews();
        List<Brass> GetBrasses();
        List<BrassView> GetBrassViews();
        List<Primer> GetPrimers();
        List<PrimerView> GetPrimerViews();
        List<Manufacturer> GetManufacturers();
        List<CartridgeView> GetAllQuantityViewsWithNoInventory();

    }
}