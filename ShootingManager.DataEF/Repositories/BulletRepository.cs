using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using Data.Core.Repositories;
using ShootingManager.Entities.Models;
using ShootingManager.Repositories.Interfaces;

namespace ShootingManager.DataEF.Repositories
{
    public class BulletRepository : Repository<ShootingEntities, Bullet>, IBulletRepository
    {
        public List<Manufacturer> GetManufacturers()
        {
            return CommonRepository.GetManufacturers(this.Context);
        }

        public List<Material> GetMaterials()
        {
            return CommonRepository.GetMaterials(this.Context);
        }

        public List<Unit> GetLengthUnits()
        {
            return CommonRepository.GetLengthUnits(this.Context);
        }

        public List<Unit> GetMassUnits()
        {
            return CommonRepository.GetMassUnits(this.Context);
        }

        public List<BulletView> GetBulletViews()
        {
            return this.Context.BulletViews.ToList();
        }

        public List<BulletType> GetBulletTypes()
        {
            return CommonRepository.GetBulletTypes(this.Context);
        }

        public override IQueryable<Bullet> GetAll()
        {
            return this.Context.Bullets.Include("BulletType").Include("Material").Include("DiameterUnit").Include("MassUnit").Include("LengthUnit").Include("Manufacturer").Include("BulletCosts").Include("BulletQuantities").Include("CartridgeLoads");
        }

        public override Bullet FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
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

    }
}