using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using Data.Core.Repositories;
using ShootingManager.Entities.Models;
using ShootingManager.Repositories.Interfaces;

namespace ShootingManager.DataEF.Repositories
{
    public class CartridgeQuantityRepository : Repository<ShootingEntities, CartridgeQuantity>, ICartridgeQuantityRepository
    {
        public override IQueryable<CartridgeQuantity> GetAll()
        {
            return this.Context.CartridgeQuantities.Include("Cartridge").Include("InventoryType").Include("QuantityUnit").Include("Cartridge.CartridgeLoad");
        }

        public override CartridgeQuantity FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }

    }
}