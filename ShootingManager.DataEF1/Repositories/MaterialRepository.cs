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
    public class MaterialRepository : Repository<ShootingContext, Material>, IMaterialRepository
    {
        public override IQueryable<Material> GetAll()
        {
            return this.Context.Materials.Include("Brasses").Include("Bullets");
        }

        public override Material FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }
    }
}