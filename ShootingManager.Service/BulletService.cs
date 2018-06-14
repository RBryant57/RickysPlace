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
    public class BulletService : IBulletService
    {
        private IBulletRepository repository;
        private IBulletCostRepository costRepository;
        private IBulletQuantityRepository quantityRepository;
        private ICartridgeLoadRepository cartridgeLoadRepository;

        public BulletService()
        {
            this.repository = new BulletRepository();
            this.cartridgeLoadRepository = new CartridgeLoadRepository();
            this.costRepository = new BulletCostRepository();
            this.quantityRepository = new BulletQuantityRepository();
        }

        public BulletService(IBulletRepository iRepository, ICartridgeLoadRepository iCartridgeLoadRepository, IBulletCostRepository iBulletCostRepository, IBulletQuantityRepository iBulletQuantityRepository)
        {
            this.repository = iRepository;
            this.cartridgeLoadRepository = iCartridgeLoadRepository;
            this.costRepository = iBulletCostRepository;
            this.quantityRepository = iBulletQuantityRepository;
        }

        public int Add(IEntity entity)
        {
            var newEntity = this.repository.Add((Bullet)entity);
            this.repository.Save();

            return newEntity.Id;
        }

        public void AddCost(IAccountingEntity entity)
        {
            this.costRepository.Add((BulletCost)entity);
            this.costRepository.Save();
        }

        public void AddQuantity(IInventoryEntity entity)
        {
            this.quantityRepository.Add((BulletQuantity)entity);
            this.quantityRepository.Save();
        }

        public void Edit(IEntity entity)
        {
            this.repository.Edit((Bullet)entity);
            this.repository.Save();
        }

        public void EditCost(IAccountingEntity entity)
        {
            this.costRepository.Edit((BulletCost)entity);
            this.costRepository.Save();
        }

        public void EditQuantity(IInventoryEntity entity)
        {
            this.quantityRepository.Edit((BulletQuantity)entity);
            this.quantityRepository.Save();
        }

        public void Delete(IEntity entity)
        {
            this.repository.Refresh();

            this.repository.Delete((Bullet)entity);
            this.repository.Save();
        }

        public void DeleteCost(IAccountingEntity entity)
        {
            this.costRepository.Refresh();

            this.costRepository.Delete((BulletCost)entity);
            this.costRepository.Save();
        }

        public void DeleteQuantity(IInventoryEntity entity)
        {
            this.quantityRepository.Refresh();

            this.quantityRepository.Delete((BulletQuantity)entity);
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

        public List<IEntity> GetAllQuantitiesWithNoInventory()
        {
            var noResult = from br in this.repository.GetAll().OfType<Bullet>()
                           where !(from bq in this.quantityRepository.GetAll()
                                   select bq.EntityId).Distinct().Contains(br.Id)
                           select br;
            var emptyResult = from brEmpty in this.repository.GetAll().OfType<Bullet>()
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
            foreach (var result in finalResult.OrderBy(b => b.Diameter).ThenBy(b => b.Mass).ToList())
            {
                finalList.Add(result);
            }

            return finalList;
        }

        public List<BulletView> GetAllQuantityViewsWithNoInventory()
        {
            var noResult = from br in this.repository.GetBulletViews()
                           where !(from bq in this.quantityRepository.GetAll()
                                   select bq.EntityId).Distinct().Contains(br.Id)
                           select br;
            var emptyResult = from brEmpty in this.repository.GetBulletViews()
                              where (from bqEmpty in this.quantityRepository.GetAll()
                                     select bqEmpty.EntityId).Distinct().Contains(brEmpty.Id)
                              select brEmpty;
            var finalResult = noResult.ToList();
            foreach (var br in emptyResult.ToList())
            {
                if (GetQuantity(br.Id) == 0)
                    finalResult.Add(br);
            }

            var finalList = new List<BulletView>();
            foreach (var result in finalResult.OrderBy(b => b.CaliberViewSortOrder).ToList())
            {
                finalList.Add(result);
            }

            return finalList;
        }

        public List<BulletView> GetBulletViews()
        {
            return this.repository.GetBulletViews();
        }

        public List<BulletType> GetBulletTypes()
        {
            return this.repository.GetBulletTypes();
        }

        public List<Manufacturer> GetManufacturers()
        {
            return this.repository.GetManufacturers();
        }

        public List<Material> GetMaterials()
        {
            return this.repository.GetMaterials();
        }

        public List<Unit> GetLengthUnits()
        {
            return this.repository.GetLengthUnits();
        }

        public List<Unit> GetMassUnits()
        {
            return this.repository.GetMassUnits();
        }

        public decimal GetQuantity(int entityId)
        {
            var quantity = this.quantityRepository.GetAll().Where(e => e.EntityId == entityId).OrderByDescending(e => e.Date);

            if (quantity.Count() == 0)
                return 0;

            return quantity.First().EndQuantity;
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

        public List<CartridgeLoad> GetCartridgeLoads()
        {
            return this.cartridgeLoadRepository.GetAll().ToList();
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

        public void Dispose()
        {

        }

    }
}