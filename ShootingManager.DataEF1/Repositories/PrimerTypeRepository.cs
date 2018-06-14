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
    public class PrimerTypeRepository : Repository<ShootingContext, PrimerType>, IPrimerTypeRepository
    {
        public override IQueryable<PrimerType> GetAll()
        {
            return this.Context.PrimerTypes.Include("Primers").Include("Calibers");
        }

        public override PrimerType FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }
    }
}