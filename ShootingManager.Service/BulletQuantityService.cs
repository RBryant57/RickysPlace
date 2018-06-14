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
    public class BulletQuantityService : IBulletQuantityService
    {
        private IBulletQuantityRepository repository;
        private IBulletRepository bulletRepository;
        private IInventoryTypeRepository inventoryTypeRepository;
        private IUnitRepository unitRepository;

        public BulletQuantityService()
        {
            this.repository = new BulletQuantityRepository();
            this.bulletRepository = new BulletRepository();
            this.inventoryTypeRepository = new InventoryTypeRepository();
            this.unitRepository = new UnitRepository();
        }

        public BulletQuantityService(IBulletQuantityRepository iRepository, IBulletRepository iBulletRepository, IInventoryTypeRepository iInventoryTypeRepository, IUnitRepository iUnitRepository)
        {
            this.repository = iRepository;
            this.bulletRepository = iBulletRepository;
            this.inventoryTypeRepository = iInventoryTypeRepository;
            this.unitRepository = iUnitRepository;
        }

        public void Add(IEntity entity)
        {
            this.repository.Add((BulletQuantity)entity);
            this.repository.Save();
        }

        public void Edit(IEntity entity)
        {
            this.repository.Edit((BulletQuantity)entity);
            this.repository.Save();
        }

        public void Delete(IEntity entity)
        {
            this.repository.Refresh();

            this.repository.Delete((BulletQuantity)entity);
            this.repository.Save();
        }

        public IEntity FindById(object id)
        {
            return this.repository.FindById(id);
        }

        public List<IEntity> GetAll()
        {
            var list = new List<IEntity>();
            foreach (BulletQuantity entity in this.repository.GetAll())
            {
                list.Add(entity);
            }

            return list;
        }

        public List<Bullet> GetBullets()
        {
            return this.bulletRepository.GetAll().OfType<Bullet>().ToList();
        }

        public List<BulletView> GetBulletViews()
        {
            return this.bulletRepository.GetBulletViews();
        }

        public List<Bullet> GetBulletsWithNoInventory()
        {
            var noResult = from br in this.bulletRepository.GetAll().OfType<Bullet>()
                         where !(from bq in this.repository.GetAll().OfType<BulletQuantity>()
                                 select bq.BulletId).Distinct().Contains(br.Id)
                         select br;
            var emptyResult = from brEmpty in this.bulletRepository.GetAll().OfType<Bullet>()
                              where (from bqEmpty in this.repository.GetAll().OfType<BulletQuantity>()
                                     select bqEmpty.BulletId).Distinct().Contains(brEmpty.Id)
                              select brEmpty;
            var finalResult = noResult.ToList();
            foreach (var br in emptyResult.ToList())
            {
                if (GetQuantity(br.Id) == 0)
                    finalResult.Add(br);
            }

            return finalResult.OrderBy(b => b.Diameter).ToList();
        }

        public List<BulletView> GetBulletViewsWithNoInventory()
        {
            var noResult = from br in this.bulletRepository.GetBulletViews()
                           where !(from bq in this.repository.GetAll().OfType<BulletQuantity>()
                                   select bq.BulletId).Distinct().Contains(br.Id)
                           select br;
            var emptyResult = from brEmpty in this.bulletRepository.GetBulletViews()
                              where (from bqEmpty in this.repository.GetAll().OfType<BulletQuantity>()
                                      select bqEmpty.BulletId).Distinct().Contains(brEmpty.Id)
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
            var quantity = this.repository.GetAll().Where(e => e.BulletId == entityId).OrderByDescending(e => e.Date);

            if (quantity.Count() == 0)
                return 0;

            return quantity.First().EndQuantity;
        }

        public void Dispose()
        {
   
        }

    }
}