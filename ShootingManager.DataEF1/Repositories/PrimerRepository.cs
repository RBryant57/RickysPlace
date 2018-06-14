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
    public class PrimerRepository : Repository<ShootingContext, Primer>, IPrimerRepository
    {
        public List<PrimerType> GetPrimerTypes()
        {
            return CommonRepository.GetPrimerTypes(this.Context);
        }

        public List<Manufacturer> GetManufacturers()
        {
            return CommonRepository.GetManufacturers(this.Context);
        }

        public List<PrimerView> GetPrimerViews()
        {
            return this.Context.PrimerViews.ToList();
        }

        public List<Unit> GetQuantityUnits()
        {
            return CommonRepository.GetQuantityUnits(this.Context);
        }

        public List<IEntity> GetInventoryTypes()
        {
            var results = new List<IEntity>();
            foreach (var result in CommonRepository.GetInventoryTypes(this.Context))
            {
                results.Add(result);
            }

            return results;
        }

        public override IQueryable<Primer> GetAll()
        {
            return this.Context.Primers.Include("Cartridges").Include("Manufacturer").Include("PrimerType").Include("PrimerCosts").Include("PrimerQuantities");
        }

        public override Primer FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }

    }
}