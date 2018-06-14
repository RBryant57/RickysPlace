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
    public class GunTypeRepository : Repository<ShootingEntities, GunType>, IGunTypeRepository
    {
        public override IQueryable<GunType> GetAll()
        {
            return this.Context.GunTypes.Include("Guns");
        }

        public override GunType FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }
    }
}