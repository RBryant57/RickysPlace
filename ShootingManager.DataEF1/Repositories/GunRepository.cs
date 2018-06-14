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
    public class GunRepository : Repository<ShootingContext, Gun>, IGunRepository
    {
        public override void Delete(Gun entity)
        {
            var gunImages = from gunImage in this.Context.GunImages
                            where gunImage.GunId == entity.Id
                            select gunImage;
            this.Context.GunImages.RemoveRange(gunImages);
            base.Delete(entity);
        }

        public List<Caliber> GetCalibers()
        {
            return CommonRepository.GetCalibers(this.Context);
        }

        public List<Manufacturer> GetManufacturers()
        {
            return CommonRepository.GetManufacturers(this.Context);
        }

        public List<GunType> GetGunTypes()
        {
            return this.Context.GunTypes.ToList();
        }

        public List<GunImage> GetGunImages()
        {
            return this.Context.GunImages.ToList();
        }

        public List<GunView> GetGunViews()
        {
            return this.Context.GunViews.ToList();
        }

        public void InsertGunImage(GunImage image)
        {
            this.Context.GunImages.Add(image);
        }

        public override IQueryable<Gun> GetAll()
        {
            return base.GetAll().Include("Caliber").Include("GunType").Include("Manufacturer").Include("GunImages").Include("ShootingSessions").Include("LengthUnit").Include("GunsCalibers");
        }

        public override Gun FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }

    }
}