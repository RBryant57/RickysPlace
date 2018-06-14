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
    public class BulletCostService : IBulletCostService
    {
        private IBulletCostRepository repository;
        private IBulletRepository bulletRepository;
        private IUnitRepository unitRepository;

        public BulletCostService()
        {
            this.repository = new BulletCostRepository();
            this.bulletRepository = new BulletRepository();
            this.unitRepository = new UnitRepository();
        }

        public BulletCostService(IBulletCostRepository iRepository, IBulletRepository iBulletRepository, IUnitRepository iUnitRepository)
        {
            this.repository = iRepository;
            this.bulletRepository = iBulletRepository;
            this.unitRepository = iUnitRepository;
        }

        public void Add(IEntity entity)
        {
            this.repository.Add((BulletCost)entity);
            this.repository.Save();
        }

        public void Edit(IEntity entity)
        {
            this.repository.Edit((BulletCost)entity);
            this.repository.Save();
        }

        public void Delete(IEntity entity)
        {
            this.repository.Refresh();

            this.repository.Delete((BulletCost)entity);
            this.repository.Save();
        }

        public IEntity FindById(object id)
        {
            return this.repository.FindById(id);
        }

        public List<IEntity> GetAll()
        {
            var list = new List<IEntity>();
            foreach (BulletCost entity in this.repository.GetAll())
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

        public List<Unit> GetQuantityUnits()
        {
            return this.repository.GetQuantityUnits();
        }

        public List<UnitView> GetQuantityUnitViews()
        {
            return this.unitRepository.GetUnitViews();
        }

        public void Dispose()
        {
   
        }

    }
}