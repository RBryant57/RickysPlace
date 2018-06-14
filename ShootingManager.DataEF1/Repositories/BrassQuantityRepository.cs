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
    public class BrassQuantityRepository : Repository<ShootingContext, BrassQuantity>, IBrassQuantityRepository
    {
        public override IQueryable<BrassQuantity> GetAll()
        {
            return this.Context.BrassQuantities.Include("Brass").Include("InventoryType").Include("QuantityUnit");
        }

        public override BrassQuantity FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }

        //public List<Brass> GetBrasses()
        //{
        //    return CommonRepository.GetBrasses(this.Context);
        //}

        //public List<BrassView> GetBrassViews()
        //{
        //    return this.Context.BrassViews.ToList();
        //}

        //public List<Unit> GetQuantityUnits()
        //{
        //    return CommonRepository.GetQuantityUnits(this.Context);
        //}

        //public List<UnitView> GetQuantityUnitViews()
        //{
        //    return CommonRepository.GetQuantityUnitViews(this.Context);
        //}

        //public List<InventoryType> GetInventoryTypes()
        //{
        //    return CommonRepository.GetInventoryTypes(this.Context);
        //}
    }
}