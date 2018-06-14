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
    public class BrassCostRepository : Repository<ShootingContext1, BrassCost>, IBrassCostRepository
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