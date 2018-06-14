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
    public class PowderQuantityService : IPowderQuantityService
    {
        private IPowderQuantityRepository repository;
        private IPowderRepository powderRepository;
        private IInventoryTypeRepository inventoryTypeRepository;
        private IUnitRepository unitRepository;

        public PowderQuantityService()
        {
            this.repository = new PowderQuantityRepository();
            this.powderRepository = new PowderRepository();
            this.inventoryTypeRepository = new InventoryTypeRepository();
            this.unitRepository = new UnitRepository();
        }

        public PowderQuantityService(IPowderQuantityRepository iRepository, IPowderRepository iPowderRepository, IInventoryTypeRepository iInventoryTypeRepository, IUnitRepository iUnitRepository)
        {
            this.repository = iRepository;
            this.powderRepository = iPowderRepository;
            this.inventoryTypeRepository = iInventoryTypeRepository;
            this.unitRepository = iUnitRepository;
        }

        public void Add(IEntity entity)
        {
            this.repository.Add((PowderQuantity)entity);
            this.repository.Save();
        }

        public void Edit(IEntity entity)
        {
            this.repository.Edit((PowderQuantity)entity);
            this.repository.Save();
        }

        public void Delete(IEntity entity)
        {
            this.repository.Refresh();

            this.repository.Delete((PowderQuantity)entity);
            this.repository.Save();
        }

        public IEntity FindById(object id)
        {
            return this.repository.FindById(id);
        }

        public List<IEntity> GetAll()
        {
            var list = new List<IEntity>();
            foreach (PowderQuantity entity in this.repository.GetAll())
            {
                list.Add(entity);
            }

            return list;
        }

        public List<Powder> GetPowders()
        {
            return this.powderRepository.GetAll().OfType<Powder>().ToList();
        }

        public List<PowderView> GetPowderViews()
        {
            return this.powderRepository.GetPowderViews();
        }

        public List<Powder> GetPowdersWithNoInventory()
        {
            var noResult = from br in this.powderRepository.GetAll().OfType<Powder>()
                         where !(from bq in this.repository.GetAll().OfType<PowderQuantity>()
                                 select bq.PowderId).Distinct().Contains(br.Id)
                         select br;
            var emptyResult = from brEmpty in this.powderRepository.GetAll().OfType<Powder>()
                              where (from bqEmpty in this.repository.GetAll().OfType<PowderQuantity>()
                                     select bqEmpty.PowderId).Distinct().Contains(brEmpty.Id)
                              select brEmpty;
            var finalResult = noResult.ToList();
            foreach (var br in emptyResult.ToList())
            {
                if (GetQuantity(br.Id) == 0)
                    finalResult.Add(br);
            }

            return finalResult.OrderBy(b => b.Name).ToList();
        }

        public List<PowderView> GetPowderViewsWithNoInventory()
        {
            var noResult = from br in this.powderRepository.GetPowderViews()
                           where !(from bq in this.repository.GetAll().OfType<PowderQuantity>()
                                   select bq.PowderId).Distinct().Contains(br.Id)
                           select br;
            var emptyResult = from brEmpty in this.powderRepository.GetPowderViews()
                              where (from bqEmpty in this.repository.GetAll().OfType<PowderQuantity>()
                                      select bqEmpty.PowderId).Distinct().Contains(brEmpty.Id)
                              select brEmpty;
            var finalResult = noResult.ToList();
            foreach(var br in emptyResult.ToList())
            {
                if (GetQuantity(br.Id) == 0)
                    finalResult.Add(br);
            }

            return finalResult.OrderBy(bv => bv.PowderName).ToList();
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

        public decimal GetQuantity(int entityId)
        {
            var quantity = this.repository.GetAll().Where(e => e.PowderId == entityId).OrderByDescending(e => e.Date);

            if (quantity.Count() == 0)
                return 0;

            return quantity.First().EndQuantity;
        }

        public void Dispose()
        {
   
        }

    }
}