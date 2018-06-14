using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.DataEF.Repositories;
using ShootingManager.Entities.Models;
using ShootingManager.Repositories.Interfaces;
using ShootingManager.Service.Interfaces;

namespace ShootingManager.Service
{
    public class PowderService : IPowderService
    {
        private IPowderRepository repository;
        private IPowderCostRepository costRepository;
        private IPowderQuantityRepository quantityRepository;
        private ICartridgeLoadRepository cartridgeLoadRepository;

        public PowderService()
        {
            this.repository = new PowderRepository();
            this.costRepository = new PowderCostRepository();
            this.quantityRepository = new PowderQuantityRepository();
            this.cartridgeLoadRepository = new CartridgeLoadRepository();
        }

        public PowderService(IPowderRepository iRepository, IPowderCostRepository iPowderCostRepository, IPowderQuantityRepository iPowderQuantityRepository, ICartridgeLoadRepository iCartridgeLoadRepository)
        {
            this.repository = iRepository;
            this.costRepository = iPowderCostRepository;
            this.quantityRepository = iPowderQuantityRepository;
            this.cartridgeLoadRepository = iCartridgeLoadRepository;
        }

        public int Add(IEntity entity)
        {
            var newEntity = this.repository.Add((Powder)entity);
            this.repository.Save();

            return newEntity.Id;
        }

        public void AddCost(IAccountingEntity entity)
        {
            this.costRepository.Add((PowderCost)entity);
            this.costRepository.Save();
        }

        public void AddQuantity(IInventoryEntity entity)
        {
            this.quantityRepository.Add((PowderQuantity)entity);
            this.quantityRepository.Save();
        }

        public void Edit(IEntity entity)
        {
            this.repository.Edit((Powder)entity);
            this.repository.Save();
        }

        public void EditCost(IAccountingEntity entity)
        {
            this.costRepository.Edit((PowderCost)entity);
            this.costRepository.Save();
        }

        public void EditQuantity(IInventoryEntity entity)
        {
            this.quantityRepository.Edit((PowderQuantity)entity);
            this.quantityRepository.Save();
        }

        public void Delete(IEntity entity)
        {
            this.repository.Delete((Powder)entity);
            this.repository.Save();
        }

        public void DeleteCost(IAccountingEntity entity)
        {
            this.costRepository.Delete((PowderCost)entity);
            this.costRepository.Save();
        }

        public void DeleteQuantity(IInventoryEntity entity)
        {
            this.quantityRepository.Delete((PowderQuantity)entity);
            this.quantityRepository.Save();
        }

        public IEntity FindById(object id)
        {
            return this.repository.FindById(id);
        }

        public IAccountingEntity FindCostById(object id)
        {
            return this.costRepository.FindById(id);
        }

        public IInventoryEntity FindQuantityById(object id)
        {
            return this.quantityRepository.FindById(id);
        }

        public List<IEntity> GetAll()
        {
            var list = new List<IEntity>();

            foreach (var entity in this.repository.GetAll())
            {
                list.Add(entity);
            }

            return list;
        }

        public List<IAccountingEntity> GetAllCosts()
        {
            var list = new List<IAccountingEntity>();

            foreach (var entity in this.costRepository.GetAll())
            {
                list.Add(entity);
            }

            return list;
        }

        public List<IEntity> GetAllQuantities()
        {
            var list = new List<IEntity>();

            foreach (var entity in this.quantityRepository.GetAll())
            {
                list.Add(entity);
            }

            return list;
        }

        public List<Manufacturer> GetManufacturers()
        {
            return this.repository.GetManufacturers();
        }

        public List<PowderType> GetPowderTypes()
        {
            return this.repository.GetPowderTypes();
        }

        public List<PowderShape> GetPowderShapes()
        {
            return this.repository.GetPowderShapes();
        }

        public List<PowderView> GetPowderViews()
        {
            return this.repository.GetPowderViews();
        }

        public List<IEntity> GetQuantityUnits()
        {
            var list = new List<IEntity>();
            foreach (Unit entity in this.repository.GetQuantityUnits())
            {
                list.Add(entity);
            }

            return list;
        }

        public void Dispose()
        {

        }

        public List<CartridgeLoad> GetCartridgeLoads()
        {
            return this.cartridgeLoadRepository.GetAll().OfType<CartridgeLoad>().ToList();
        }

        public List<IEntity> GetAllQuantitiesWithNoInventory()
        {
            var noResult = from br in this.repository.GetAll()
                           where !(from bq in this.quantityRepository.GetAll()
                                   select bq.EntityId).Distinct().Contains(br.Id)
                           select br;
            var emptyResult = from brEmpty in this.repository.GetAll()
                              where (from bqEmpty in this.quantityRepository.GetAll()
                                     select bqEmpty.EntityId).Distinct().Contains(brEmpty.Id)
                              select brEmpty;
            var finalResult = noResult.ToList();
            foreach (var br in emptyResult.ToList())
            {
                if (GetQuantity(br.Id) == 0)
                    finalResult.Add(br);
            }

            var finalList = new List<IEntity>();
            foreach (var result in finalResult.OrderBy(b => b.Name).ToList())
            {
                finalList.Add(result);
            }

            return finalList;
        }

        public List<PowderView> GetAllQuantityViewsWithNoInventory()
        {
            var noResult = from br in this.repository.GetPowderViews()
                           where !(from bq in this.quantityRepository.GetAll()
                                   select bq.EntityId).Distinct().Contains(br.Id)
                           select br;
            var emptyResult = from brEmpty in this.repository.GetPowderViews()
                              where (from bqEmpty in this.quantityRepository.GetAll()
                                     select bqEmpty.EntityId).Distinct().Contains(brEmpty.Id)
                              select brEmpty;
            var finalResult = noResult.ToList();
            foreach (var br in emptyResult.ToList())
            {
                if (GetQuantity(br.Id) == 0)
                    finalResult.Add(br);
            }

            var finalList = new List<PowderView>();
            foreach (var result in finalResult.OrderBy(b => b.PowderName).ToList())
            {
                finalList.Add(result);
            }

            return finalList;
        }

        public decimal GetQuantity(int entityId)
        {
            var quantity = this.quantityRepository.GetAll().Where(e => e.EntityId == entityId).OrderByDescending(e => e.Date);

            if (quantity.Count() == 0)
                return 0;

            return quantity.First().EndQuantity;
        }

        public List<IEntity> GetInventoryTypes()
        {
            var list = new List<IEntity>();
            foreach (InventoryType entity in this.repository.GetInventoryTypes())
            {
                list.Add(entity);
            }

            return list;

        }
    }
}