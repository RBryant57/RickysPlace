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

namespace ShootingManager.DataEF.Repositories
{
    public class PowderRepository : Repository<ShootingEntities, Powder>, IPowderRepository
    {
        public List<Manufacturer> GetManufacturers()
        {
            return CommonRepository.GetManufacturers(this.Context);
        }

        public List<Unit> GetMassUnits()
        {
            return CommonRepository.GetMassUnits(this.Context);
        }

        public List<PowderType> GetPowderTypes()
        {
            return CommonRepository.GetPowderTypes(this.Context);
        }

        public List<PowderShape> GetPowderShapes()
        {
            return CommonRepository.GetPowderShapes(this.Context);
        }

        public List<PowderView> GetPowderViews()
        {
            return this.Context.PowderViews.ToList();
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

        public override IQueryable<Powder> GetAll()
        {
            return this.Context.Powders.Include("CartridgeLoads").Include("Manufacturer").Include("PowderShape").Include("PowderType").Include("PowderCosts").Include("PowderQuantities");
        }

        public override Powder FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }
    }
}