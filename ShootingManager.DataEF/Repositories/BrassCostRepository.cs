using System.Data;
using System.Linq;
using Data.Core.Repositories;
using ShootingManager.Entities.Models;
using ShootingManager.Repositories.Interfaces;

namespace ShootingManager.DataEF.Repositories
{
    public class BrassCostRepository : Repository<ShootingEntities, BrassCost>, IBrassCostRepository
    {
        public override IQueryable<BrassCost> GetAll()
        {
            return this.Context.BrassCosts.Include("Brass").Include("QuantityUnit");
        }

        public override BrassCost FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }

    }
}