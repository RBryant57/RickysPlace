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
    public class BulletCostRepository : Repository<ShootingContext, BulletCost>, IBulletCostRepository
    {
        public override IQueryable<BulletCost> GetAll()
        {
            return this.Context.BulletCosts.Include("Bullet").Include("QuantityUnit");
        }

        public override BulletCost FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }

    }
}