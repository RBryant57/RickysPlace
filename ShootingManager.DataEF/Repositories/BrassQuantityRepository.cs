using System.Data;
using System.Linq;
using Data.Core.Repositories;
using ShootingManager.Entities.Models;
using ShootingManager.Repositories.Interfaces;

namespace ShootingManager.DataEF.Repositories
{
    public class BrassQuantityRepository : Repository<ShootingEntities, BrassQuantity>, IBrassQuantityRepository
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