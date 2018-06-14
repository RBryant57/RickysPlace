using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.EFData.Repositories;
using ShootingManager.Entities.Models;
using ShootingManager.Repositories.Interfaces;
using ShootingManager.Service.Interfaces;

namespace ShootingManager.Service
{
    public class BrassQuantityService : IBrassQuantityService
    {
        private IBrassQuantityRepository repository;
        private IBrassRepository brassRepository;
        private IInventoryTypeRepository inventoryTypeRepository;
        private IUnitRepository unitRepository;

        public BrassQuantityService()
        {
            this.repository = new BrassQuantityRepository();
            this.brassRepository = new BrassRepository();
            this.inventoryTypeRepository = new InventoryTypeRepository();
            this.unitRepository = new UnitRepository();
        }

        public BrassQuantityService(IBrassQuantityRepository iRepository, IBrassRepository iBrassRepository, IInventoryTypeRepository iInventoryTypeRepository, IUnitRepository iUnitRepository)
        {
            this.repository = iRepository;
            this.brassRepository = iBrassRepository;
            this.inventoryTypeRepository = iInventoryTypeRepository;
            this.unitRepository = iUnitRepository;
        }

        public void Add(IEntity entity)
        {
            this.repository.Add((BrassQuantity)entity);
            this.repository.Save();
        }

        public void Edit(IEntity entity)
        {
            this.repository.Edit((BrassQuantity)entity);
            this.repository.Save();
        }

        public void Delete(IEntity entity)
        {
            this.repository.Refresh();

            this.repository.Delete((BrassQuantity)entity);
            this.repository.Save();
        }

        public IEntity FindById(object id)
        {
            return this.repository.FindById(id);
        }

        public List<IEntity> GetAll()
        {
            var list = new List<IEntity>();
            foreach (BrassQuantity entity in this.repository.GetAll())
            {
                list.Add(entity);
            }

            return list;
        }

        public List<Brass> GetBrasses()
        {
            return this.brassRepository.GetAll().OfType<Brass>().ToList();
        }

        public List<BrassView> GetBrassViews()
        {
            return this.brassRepository.GetBrassViews();
        }

        public List<Brass> GetBrassesWithNoInventory()
        {
            var noResult = from br in this.brassRepository.GetAll().OfType<Brass>()
                         where !(from bq in this.repository.GetAll().OfType<BrassQuantity>()
                                 select bq.BrassId).Distinct().Contains(br.Id)
                         select br;
            var emptyResult = from brEmpty in this.brassRepository.GetAll().OfType<Brass>()
                              where (from bqEmpty in this.repository.GetAll().OfType<BrassQuantity>()
                                     select bqEmpty.BrassId).Distinct().Contains(brEmpty.Id)
                              select brEmpty;
            var finalResult = noResult.ToList();
            foreach (var br in emptyResult.ToList())
            {
                if (GetQuantity(br.Id) == 0)
                    finalResult.Add(br);
            }

            return finalResult.OrderBy(b => b.Caliber.SortOrder).ToList();
        }

        public List<BrassView> GetBrassViewsWithNoInventory()
        {
            var noResult = from br in this.brassRepository.GetBrassViews()
                           where !(from bq in this.repository.GetAll().OfType<BrassQuantity>()
                                   select bq.BrassId).Distinct().Contains(br.Id)
                           select br;
            var emptyResult = from brEmpty in this.brassRepository.GetBrassViews()
                              where (from bqEmpty in this.repository.GetAll().OfType<BrassQuantity>()
                                      select bqEmpty.BrassId).Distinct().Contains(brEmpty.Id)
                              select brEmpty;
            var finalResult = noResult.ToList();
            foreach(var br in emptyResult.ToList())
            {
                if (GetQuantity(br.Id) == 0)
                    finalResult.Add(br);
            }

            return finalResult.OrderBy(bv => bv.CaliberViewSortOrder).ToList();
        }

        public List<InventoryType> GetInventoryTypes()
        {
            return this.inventoryTypeRepository.GetAll().OfType<InventoryType>().ToList();
        }

        public List<Unit> GetQuantityUnits()
        {
            return this.repository.GetQuantityUnits();
        }

        public List<UnitView> GetQuantityUnitViews()
        {
            return this.unitRepository.GetUnitViews();
        }

        public int GetQuantity(int entityId)
        {
            var quantity = this.repository.GetAll().Where(e => e.BrassId == entityId).OrderByDescending(e => e.Date);

            if (quantity.Count() == 0)
                return 0;

            return quantity.First().EndQuantity;
        }

        public void Dispose()
        {
   
        }

    }
}