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
    public class CartridgeLoadService : ICartridgeLoadService
    {
        private ICartridgeLoadRepository repository;

        public CartridgeLoadService()
        {
            this.repository = new CartridgeLoadRepository();
        }

        public CartridgeLoadService(ICartridgeLoadRepository iRepository)
        {
            this.repository = iRepository;
        }

        public int Add(IEntity entity)
        {
            var newEntity = this.repository.Add((CartridgeLoad)entity);
            this.repository.Save();

            return newEntity.Id;
        }

        public void Edit(IEntity entity)
        {
            this.repository.Edit((CartridgeLoad)entity);
            this.repository.Save();
        }

        public void Delete(IEntity entity)
        {
            this.repository.Delete((CartridgeLoad)entity);
            this.repository.Save();
        }

        public IEntity FindById(object id)
        {
            return this.repository.FindById(id);
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

        public List<Caliber> GetCalibers()
        {
            return this.repository.GetCalibers().ToList();
        }

        public List<CaliberView> GetCaliberViews()
        {
            return this.repository.GetCaliberViews().ToList();
        }

        public List<Bullet> GetBullets()
        {
            return this.repository.GetBullets().ToList();
        }

        public List<BulletView> GetBulletViews()
        {
            return this.repository.GetBulletViews().ToList();
        }

        public List<Powder> GetPowders()
        {
            return this.repository.GetPowders().ToList();
        }

        public List<Unit> GetMassUnits()
        {
            return this.repository.GetMassUnits().ToList();
        }

        public List<Unit> GetLengthUnits()
        {
            return this.repository.GetLengthUnits().ToList();
        }

        public List<Unit> GetVelocityUnits()
        {
            return this.repository.GetVelocityUnits().ToList();
        }

        public List<Unit> GetPressureUnits()
        {
            return this.repository.GetPressureUnits().ToList();
        }

        public List<CartridgeLoadView> GetCartridgeLoadViews()
        {
            return this.repository.GetCartridgeLoadViews();
        }

        public void Dispose()
        {

        }
    }
}