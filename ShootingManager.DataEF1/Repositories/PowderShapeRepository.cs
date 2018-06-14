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
    public class PowderShapeRepository : Repository<ShootingContext, PowderShape>, IPowderShapeRepository
    {
        public override IQueryable<PowderShape> GetAll()
        {
            return this.Context.PowderShapes.Include("Powders");
        }

        public override PowderShape FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }
    }
}