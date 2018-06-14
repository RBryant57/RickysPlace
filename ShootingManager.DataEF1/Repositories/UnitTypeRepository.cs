using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Repositories;
using ShootingManager.Entities.Models;
using ShootingManager.Repositories.Interfaces;

namespace ShootingManager.EFData.Repositories
{
    public class UnitTypeRepository : Repository<ShootingContext, UnitType>, IUnitTypeRepository
    {
        public override IQueryable<UnitType> GetAll()
        {
            return this.Context.UnitTypes.Include("Units");
        }

        public override UnitType FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }
    }
}