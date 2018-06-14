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
    public class CartridgeRepository : Repository<ShootingContext, Cartridge>, ICartridgeRepository
    {

        public List<CartridgeLoad> GetCartridgeLoads()
        {
            return CommonRepository.GetCartridgeLoads(this.Context);
        }

        public List<Brass> GetBrasses()
        {
            return CommonRepository.GetBrasses(this.Context);
        }

        public List<BrassView> GetBrassViews()
        {
            return this.Context.BrassViews.ToList();
        }

        public List<Primer> GetPrimers()
        {
            return CommonRepository.GetPrimers(this.Context);
        }

        public List<PrimerView> GetPrimerViews()
        {
            return this.Context.PrimerViews.ToList();
        }

        public List<Manufacturer> GetManufacturers()
        {
            return CommonRepository.GetManufacturers(this.Context);
        }

        public List<CartridgeView> GetCartridgeViews()
        {
            return this.Context.CartridgeViews.ToList();
        }

        public override IQueryable<Cartridge> GetAll()
        {
            return this.Context.Cartridges.Include("Brass").Include("CartridgeLoad").Include("Manufacturer").Include("Primer").Include("CartridgeQuantities").Include("ShootingSessions").Include("CartridgeCosts");
        }

        public override Cartridge FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }

        public List<CartridgeLoadView> GetCartridgeLoadViews()
        {
            return this.Context.CartridgeLoadViews.ToList();
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