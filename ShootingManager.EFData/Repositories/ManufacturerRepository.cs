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
    public class ManufacturerRepository : Repository<ShootingContext1, Manufacturer>, IManufacturerRepository
    {
        public override IQueryable<Manufacturer> GetAll()
        {
            return this.Context.Manufacturers.Include("Brasses").Include("Bullets").Include("Cartridges").Include("Guns").Include("Powders").Include("Primers");
        }

        public override Manufacturer FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }
    }
}