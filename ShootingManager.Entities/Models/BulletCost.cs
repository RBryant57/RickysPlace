using System;
using System.Collections.Generic;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public partial class BulletCost : IEntity, IAccountingEntity
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public System.DateTime Date { get; set; }
        public int Quantity { get; set; }
        public int QuantityUnitId { get; set; }
        public decimal Cost { get; set; }
        public string Notes { get; set; }
        public virtual Bullet Bullet { get; set; }
        public virtual Unit QuantityUnit { get; set; }
        public void Dispose()
        {

        }
    }
}
