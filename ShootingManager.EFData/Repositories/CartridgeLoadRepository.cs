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
    public class CartridgeLoadRepository : Repository<ShootingContext1, CartridgeLoad>, ICartridgeLoadRepository
    { 
        public List<Caliber> GetCalibers()
        {
            return CommonRepository.GetCalibers(this.Context);
        }

        public List<CaliberView> GetCaliberViews()
        {
            return this.Context.CaliberViews.ToList();
        }

        public List<Bullet> GetBullets()
        {
            return CommonRepository.GetBullets(this.Context);
        }

        public List<BulletView> GetBulletViews()
        {
            return this.Context.BulletViews.ToList();
        }

        public List<Powder> GetPowders()
        {
            return CommonRepository.GetPowders(this.Context);
        }

        public List<Unit> GetLengthUnits()
        {
            return CommonRepository.GetLengthUnits(this.Context);
        }

        public List<Unit> GetMassUnits()
        {
            return CommonRepository.GetMassUnits(this.Context);
        }

        public List<Unit> GetVelocityUnits()
        {
            return CommonRepository.GetVelocityUnits(this.Context);
        }

        public List<Unit> GetPressureUnits()
        {
            return CommonRepository.GetPressureUnits(this.Context);
        }

        public List<CartridgeLoadView> GetCartridgeLoadViews()
        {
            return this.Context.CartridgeLoadViews.ToList();
        }

        public override IQueryable<CartridgeLoad> GetAll()
        {
            return this.Context.CartridgeLoads.Include("Bullet").Include("Caliber").Include("Cartridges").Include("Powder").Include("PowderWeightUnit").Include("COLUnit").Include("VelocityUnit").Include("PressureUnit");
        }

        public override CartridgeLoad FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }

    }
}