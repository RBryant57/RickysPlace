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
    public class BrassService : IBrassService
    {
        private IBrassRepository repository;
        private IBrassCostRepository costRepository;
        private IBrassQuantityRepository quantityRepository;
        private ICartridgeRepository cartridgeRepository;

        public BrassService()
        {
            this.repository = new BrassRepository();
            this.costRepository = new BrassCostRepository();
            this.quantityRepository = new BrassQuantityRepository();
            this.cartridgeRepository = new CartridgeRepository();
        }

        public BrassService(IBrassRepository iRepository, IBrassCostRepository iBrassCostRepository, IBrassQuantityRepository iBrassQuantityRepository, ICartridgeRepository iCartridgeRepository)
        {
            this.repository = iRepository;
            this.costRepository = iBrassCostRepository;
            this.quantityRepository = iBrassQuantityRepository;
            this.cartridgeRepository = iCartridgeRepository;
        }

        public int Add(IEntity entity)
        {
            var newEntity = this.repository.Add((Brass)entity);
            this.repository.Save();

            return newEntity.Id;
        }

        public void AddCost(IAccountingEntity entity)
        {
            this.costRepository.Add((BrassCost)entity);
            this.costRepository.Save();
        }

        public void AddQuantity(IInventoryEntity entity)
        {
            this.quantityRepository.Add((BrassQuantity)entity);
            this.quantityRepository.Save();
        }

        public void Edit(IEntity entity)
        {
            this.repository.Edit((Brass)entity);
            this.repository.Save();
        }

        public void EditCost(IAccountingEntity entity)
        {
            this.costRepository.Edit((BrassCost)entity);
            this.costRepository.Save();
        }

        public void EditQuantity(IInventoryEntity entity)
        {
            this.quantityRepository.Edit((BrassQuantity)entity);
            this.quantityRepository.Save();
        }

        public void Delete(IEntity entity)
        {
            this.repository.Refresh();

            this.repository.Delete((Brass)entity);
            this.repository.Save();
        }

        public void DeleteCost(IAccountingEntity entity)
        {
            this.costRepository.Refresh();

            this.costRepository.Delete((BrassCost)entity);
            this.costRepository.Save();
        }

        public void DeleteQuantity(IInventoryEntity entity)
        {
            this.quantityRepository.Refresh();

            this.quantityRepository.Delete((BrassQuantity)entity);
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
            foreach (Brass brass in this.repository.GetAll())
            {
                list.Add(brass);
            }

            return list;
        }

        public List<IAccountingEntity> GetAllCosts()
        {
            var list = new List<IAccountingEntity>();
            foreach (BrassCost entity in this.costRepository.GetAll())
            {
                list.Add(entity);
            }

            return list;
        }

        public List<IEntity> GetAllQuantities()
        {
            var list = new List<IEntity>();
            foreach (BrassQuantity entity in this.quantityRepository.GetAll())
            {
                list.Add(entity);
            }

            return list;
        }

        public List<IEntity> GetAllQuantitiesWithNoInventory()
        {
            var noResult = from br in this.repository.GetAll().OfType<Brass>()
                           where !(from bq in this.quantityRepository.GetAll()
                                   select bq.EntityId).Distinct().Contains(br.Id)
                           select br;
            var emptyResult = from brEmpty in this.repository.GetAll().OfType<Brass>()
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
            foreach(var result in finalResult.OrderBy(b => b.Caliber.SortOrder).ToList())
            {
                finalList.Add(result);
            }

            return finalList;
        }

        public List<BrassView> GetAllQuantityViewsWithNoInventory()
        {
            var noResult = from br in this.repository.GetBrassViews()
                           where !(from bq in this.quantityRepository.GetAll()
                                   select bq.EntityId).Distinct().Contains(br.Id)
                           select br;
            var emptyResult = from brEmpty in this.repository.GetBrassViews()
                              where (from bqEmpty in this.quantityRepository.GetAll()
                                     select bqEmpty.EntityId).Distinct().Contains(brEmpty.Id)
                              select brEmpty;
            var finalResult = noResult.ToList();
            foreach (var br in emptyResult.ToList())
            {
                if (GetQuantity(br.Id) == 0)
                    finalResult.Add(br);
            }

            var finalList = new List<BrassView>();
            foreach (var result in finalResult.OrderBy(b => b.CaliberViewSortOrder).ToList())
            {
                finalList.Add(result);
            }

            return finalList;
        }

        public List<BrassView> GetBrassViews()
        {
            return this.repository.GetBrassViews();
        }

        public List<Caliber> GetCalibers()
        {
            return this.repository.GetCalibers();
        }

        public List<Cartridge> GetCartridges()
        {
            return this.cartridgeRepository.GetAll().ToList();
        }

        //public List<Unit> GetLengthUnits()
        //{
        //    return this.repository.GetLengthUnits();
        //}

        public List<Manufacturer> GetManufacturers()
        {
            return this.repository.GetManufacturers();
        }

        public List<Material> GetMaterials()
        {
            return this.repository.GetMaterials();
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

        public List<IEntity> GetInventoryTypes()
        {
            var list = new List<IEntity>();
            foreach (InventoryType entity in this.repository.GetInventoryTypes())
            {
                list.Add(entity);
            }

            return list;

        }

        public int Clone(int id)
        {
            var brass = this.FindById((int)id) as Brass;
            var newBrass = new Brass();

            newBrass.CaliberId = brass.CaliberId;
            //newBrass.Length = brass.Length;
            //newBrass.LengthUnitId = brass.LengthUnitId;
            newBrass.ManufacturerId = brass.ManufacturerId;
            newBrass.MaterialId = brass.MaterialId;
            newBrass.Name = brass.Name;
            newBrass.Notes = brass.Notes;
            newBrass.ParentId = brass.Id;
            newBrass.TimesFired = brass.TimesFired + 1;

            return this.Add(newBrass);
        }

        public void Dispose()
        {
   
        }

    }
}