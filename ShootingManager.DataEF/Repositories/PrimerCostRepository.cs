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
    public class PrimerCostRepository : Repository<ShootingEntities, PrimerCost>, IPrimerCostRepository
    {
        public override IQueryable<PrimerCost> GetAll()
        {
            return this.Context.PrimerCosts.Include("Primer").Include("QuantityUnit");
        }

        public override PrimerCost FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }
    }
}