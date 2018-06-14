using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core.Interfaces
{
    public interface IInventoryService
    {
        void AddQuantity(IInventoryEntity entity);
        void EditQuantity(IInventoryEntity entity);
        void DeleteQuantity(IInventoryEntity entity);
        IInventoryEntity FindQuantityById(object id);
        List<IEntity> GetAllQuantities();
        List<IEntity> GetAllQuantitiesWithNoInventory();
        List<IEntity> GetQuantityUnits();
        decimal GetQuantity(int id);
        List<IEntity> GetInventoryTypes();
    }
}
