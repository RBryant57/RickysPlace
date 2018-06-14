using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;

namespace ShootingManager.Entities.Models
{
    public class InventoryType : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public ICollection<BrassQuantity> BrassQuantities { get; set; }
        public ICollection<BulletQuantity> BulletQuantities { get; set; }
        public ICollection<CartridgeQuantity> CartridgeQuantities { get; set; }
        public ICollection<PowderQuantity> PowderQuantities { get; set; }
        public ICollection<PrimerQuantity> PrimerQuantities { get; set; }
        public void Dispose()
        {

        }
    }
}