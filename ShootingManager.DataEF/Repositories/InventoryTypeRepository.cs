using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Repositories;
using ShootingManager.Entities.Models;
using ShootingManager.Repositories.Interfaces;

namespace ShootingManager.DataEF.Repositories
{
    public class InventoryTypeRepository : Repository<ShootingEntities, InventoryType>, IInventoryTypeRepository
    {
        public override IQueryable<InventoryType> GetAll()
        {
            //return this.Context.InventoryTypes.Include("BrassQuantities").Include("BulletQuantities").Include("CartridgeQuantities").Include("PowderQuantities").Include("PrimerQuantities");
            return this.Context.InventoryTypes.Include("BrassQuantities");
        }

        public override InventoryType FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }
    }
}