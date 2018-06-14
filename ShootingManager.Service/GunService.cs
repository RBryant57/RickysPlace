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
    public class GunService : IGunService
    {
        private IGunRepository repository;

        public GunService()
        {
            this.repository = new GunRepository();
        }

        public GunService(IGunRepository iRepository)
        {
            this.repository = iRepository;
        }

        public int Add(IEntity entity)
        {
            var newEntity = this.repository.Add((Gun)entity);
            this.repository.Save();

            return newEntity.Id;
        }

        public void Edit(IEntity entity)
        {
            this.repository.Edit((Gun)entity);
            this.repository.Save();
        }

        public void Delete(IEntity entity)
        {
            this.repository.Delete((Gun)entity);
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
            return this.repository.GetCalibers();
        }

        public List<Manufacturer> GetManufacturers()
        {
            return this.repository.GetManufacturers();
        }

        public List<GunType> GetGunTypes()
        {
            return this.repository.GetGunTypes();
        }

        public List<GunImage> GetGunImages()
        {
            return this.repository.GetGunImages();
        }

        public List<GunView> GetGunViews()
        {
            return this.repository.GetGunViews();
        }

        public void Dispose()
        {

        }

    }
}