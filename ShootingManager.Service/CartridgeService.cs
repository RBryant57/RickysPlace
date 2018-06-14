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
    public class CartridgeService : ICartridgeService
    {
        private ICartridgeRepository repository;
        private ICartridgeCostRepository costRepository;
        private ICartridgeQuantityRepository quantityRepository;

        public CartridgeService()
        {
            this.repository = new CartridgeRepository();
            this.costRepository = new CartridgeCostRepository();
            this.quantityRepository = new CartridgeQuantityRepository();
        }

        public CartridgeService(ICartridgeRepository iRepository, ICartridgeCostRepository iCostRepository, ICartridgeQuantityRepository iQuantityRepository)
        {
            this.repository = iRepository;
            this.costRepository = iCostRepository;
            this.quantityRepository = iQuantityRepository;
        }

        public int Add(IEntity entity)
        {
            var newEntity = this.repository.Add((Cartridge)entity);
            this.repository.Save();

            return newEntity.Id;
        }

        public void AddCost(IAccountingEntity entity)
        {
            this.costRepository.Add((CartridgeCost)entity);
            this.costRepository.Save();
        }

        public void AddQuantity(IInventoryEntity entity)
        {
            this.quantityRepository.Add((CartridgeQuantity)entity);
            this.quantityRepository.Save();
        }

        public void Edit(IEntity entity)
        {
            this.repository.Edit((Cartridge)entity);
            this.repository.Save();
        }

        public void EditCost(IAccountingEntity entity)
        {
            this.costRepository.Edit((CartridgeCost)entity);
            this.costRepository.Save();
        }

        public void EditQuantity(IInventoryEntity entity)
        {
            this.quantityRepository.Edit((CartridgeQuantity)entity);
            this.quantityRepository.Save();
        }

        public void Delete(IEntity entity)
        {
            this.repository.Delete((Cartridge)entity);
            this.repository.Save();
        }

        public void DeleteCost(IAccountingEntity entity)
        {
            this.costRepository.Delete((CartridgeCost)entity);
            this.costRepository.Save();
        }

        public void DeleteQuantity(IInventoryEntity entity)
        {
            this.quantityRepository.Delete((CartridgeQuantity)entity);
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

        public void Dispose()
        {

        }

        public List<CartridgeView> GetCartridgeViews()
        {
            return this.repository.GetCartridgeViews();
        }

        public List<CartridgeLoad> GetCartridgeLoads()
        {
            return this.repository.GetCartridgeLoads();
        }

        public List<CartridgeLoadView> GetCartridgeLoadViews()
        {
            return this.repository.GetCartridgeLoadViews();
        }

        public List<Brass> GetBrasses()
        {
            return this.repository.GetBrasses();
        }

        public List<BrassView> GetBrassViews()
        {
            return this.repository.GetBrassViews();
        }

        public List<Primer> GetPrimers()
        {
            return this.repository.GetPrimers();
        }

        public List<PrimerView> GetPrimerViews()
        {
            return this.repository.GetPrimerViews();
        }

        public List<Manufacturer> GetManufacturers()
        {
            return this.repository.GetManufacturers();
        }

        public List<IEntity> GetAllQuantitiesWithNoInventory()
        {
            var noResult = from br in this.repository.GetAll().OfType<Cartridge>()
                           where !(from bq in this.quantityRepository.GetAll()
                                   select bq.EntityId).Distinct().Contains(br.Id)
                           select br;
            var emptyResult = from brEmpty in this.repository.GetAll().OfType<Cartridge>()
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
            foreach (var result in finalResult.OrderBy(b => b.CartridgeLoad.Caliber.SortOrder).ToList())
            {
                finalList.Add(result);
            }

            return finalList;
        }

        public List<CartridgeView> GetAllQuantityViewsWithNoInventory()
        {
            var noResult = from br in this.repository.GetCartridgeViews()
                           where !(from bq in this.quantityRepository.GetAll()
                                   select bq.EntityId).Distinct().Contains(br.Id)
                           select br;
            var emptyResult = from brEmpty in this.repository.GetCartridgeViews()
                              where (from bqEmpty in this.quantityRepository.GetAll()
                                     select bqEmpty.EntityId).Distinct().Contains(brEmpty.Id)
                              select brEmpty;
            var finalResult = noResult.ToList();
            foreach (var br in emptyResult.ToList())
            {
                if (GetQuantity(br.Id) == 0)
                    finalResult.Add(br);
            }

            var finalList = new List<CartridgeView>();
            foreach (var result in finalResult.OrderBy(b => b.CartridgeLoadViewCaliberViewSortOrder).ToList())
            {
                finalList.Add(result);
            }

            return finalList;
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