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
    public class BrassRepository : Repository<ShootingContext, Brass>, IBrassRepository
    {
        public override Brass FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }

        public override IQueryable<Brass> GetAll()
        {
            return this.Context.Brasses.Include("Material").Include("Caliber").Include("Manufacturer").Include("LengthUnit").Include("Cartridges").Include("BrassQuantities").Include("BrassCosts");
        }

        public List<BrassView> GetBrassViews()
        {
            return this.Context.BrassViews.ToList();
        }

        public List<Caliber> GetCalibers()
        {
            return CommonRepository.GetCalibers(this.Context);
        }

        public List<Unit> GetLengthUnits()
        {
            return CommonRepository.GetLengthUnits(this.Context);
        }

        public List<Manufacturer> GetManufacturers()
        {
            return CommonRepository.GetManufacturers(this.Context);
        }

        public List<Material> GetMaterials()
        {
            return CommonRepository.GetMaterials(this.Context);
        }

        public List<Unit> GetQuantityUnits()
        {
            return CommonRepository.GetQuantityUnits(this.Context);
        }

        public List<IEntity> GetInventoryTypes()
        {
            var results = new List<IEntity>();
            foreach(var result in CommonRepository.GetInventoryTypes(this.Context))
            {
                results.Add(result);
            }

            return results;
        }

    }
}