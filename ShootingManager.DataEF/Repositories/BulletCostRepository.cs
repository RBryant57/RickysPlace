using System.Data;
using System.Linq;
using Data.Core.Repositories;
using ShootingManager.Entities.Models;
using ShootingManager.Repositories.Interfaces;

namespace ShootingManager.DataEF.Repositories
{
    public class BulletCostRepository : Repository<ShootingEntities, BulletCost>, IBulletCostRepository
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