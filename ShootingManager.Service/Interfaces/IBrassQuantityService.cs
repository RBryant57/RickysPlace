using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Service.Interfaces
{
    public interface IBrassQuantityService : IDataService
    {
        List<Brass> GetBrasses();
        List<BrassView> GetBrassViews();
        List<Brass> GetBrassesWithNoInventory();
        List<BrassView> GetBrassViewsWithNoInventory();
        List<InventoryType> GetInventoryTypes();
        List<Unit> GetQuantityUnits();
        List<UnitView> GetQuantityUnitViews();
        int GetQuantity(int entityId);
    }
}