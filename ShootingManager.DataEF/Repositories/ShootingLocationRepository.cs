using System;
using System.Collections.Generic;
using System.Data;
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
    public class ShootingLocationRepository : Repository<ShootingEntities, ShootingLocation>, IShootingLocationRepository
    {
        public override IQueryable<ShootingLocation> GetAll()
        {
            return this.Context.ShootingLocations.Include("ShootingSessions");
        }

        public override ShootingLocation FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }
    }
}