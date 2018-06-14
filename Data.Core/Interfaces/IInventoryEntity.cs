using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Core.Interfaces
{
    public interface IInventoryEntity : IDisposable
    {
        int Id { get; set; }
        int EntityId { get; set; }
        int InventoryTypeId { get; set; }
        System.DateTime Date { get; set; }
        int StartQuantity { get; set; }
        int EndQuantity { get; set; }
        int Change { get; set; }
        int QuantityUnitId { get; set; }
    }
}