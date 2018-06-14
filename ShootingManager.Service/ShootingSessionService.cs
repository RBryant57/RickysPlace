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
    public class ShootingSessionService : IShootingSessionService
    {
        private IShootingSessionRepository repository;

        public ShootingSessionService()
        {
            this.repository = new ShootingSessionRepository();
        }

        public ShootingSessionService(IShootingSessionRepository iRepository)
        {
            this.repository = iRepository;
        }

        public int Add(IEntity entity)
        {
            var newEntity = this.repository.Add((ShootingSession)entity);
            this.repository.Save();

            return newEntity.Id;
        }

        public void Edit(IEntity entity)
        {
            this.repository.Edit((ShootingSession)entity);
            this.repository.Save();
        }

        public void Delete(IEntity entity)
        {
            this.repository.Delete((ShootingSession)entity);
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

        public List<ShootingLocation> GetShootingLocations()
        {
            return this.repository.GetShootingLocations().ToList();
        }

        public List<Gun> GetGuns()
        {
            return this.repository.GetGuns().ToList();
        }

        public List<Cartridge> GetCartridges()
        {
            return this.repository.GetCartridges().ToList();
        }

        public List<ShootingSessionView> GetShootingSessionViews()
        {
            return this.repository.GetShootingSessionViews().ToList();
        }

        public List<ShootingLocationView> GetShootingLocationViews()
        {
            return this.repository.GetShootingLocationViews().ToList();
        }

        public void Dispose()
        {

        }

    }
}