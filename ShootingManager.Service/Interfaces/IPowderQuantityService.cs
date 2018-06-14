using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Service.Interfaces
{
    public interface IPowderQuantityService : IDataService
    {
        List<Powder> GetPowders();
        List<PowderView> GetPowderViews();
        List<Powder> GetPowdersWithNoInventory();
        List<PowderView> GetPowderViewsWithNoInventory();
        List<InventoryType> GetInventoryTypes();
        List<Unit> GetQuantityUnits();
        List<UnitView> GetQuantityUnitViews();
        decimal GetQuantity(int entityId);
    }
}