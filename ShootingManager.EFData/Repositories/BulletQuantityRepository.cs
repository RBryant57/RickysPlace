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

namespace ShootingManager.EFData.Repositories
{
    public class BulletQuantityRepository : Repository<ShootingContext1, BulletQuantity>, IBulletQuantityRepository
    {
        public override IQueryable<BulletQuantity> GetAll()
        {
            return this.Context.BulletQuantities.Include("Bullet").Include("InventoryType").Include("QuantityUnit");
        }

        public override BulletQuantity FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }

    }
}