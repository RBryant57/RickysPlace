using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public partial class PowderQuantity : IEntity, IInventoryEntity
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public int InventoryTypeId { get; set; }
        public System.DateTime Date { get; set; }
        public int StartQuantity { get; set; }
        public int EndQuantity { get; set; }
        public int Change { get; set; }
        public int QuantityUnitId { get; set; }
        public string Notes { get; set; }
        public virtual Powder Powder { get; set; }
        public virtual InventoryType InventoryType { get; set; }
        public virtual Unit QuantityUnit { get; set; }

        public void Dispose() { }
    }
}
