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

namespace ShootingManager.EFData.Repositories
{
    public class PowderTypeRepository : Repository<ShootingContext, PowderType>, IPowderTypeRepository
    {
        public override IQueryable<PowderType> GetAll()
        {
            return this.Context.PowderTypes.Include("Powders");
        }

        public override PowderType FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }
    }
}