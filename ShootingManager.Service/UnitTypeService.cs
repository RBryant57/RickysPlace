﻿using System;
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
    public class UnitTypeService : IUnitTypeService
    {
        private IUnitTypeRepository repository;

        public UnitTypeService()
        {
            this.repository = new UnitTypeRepository();
        }

        public UnitTypeService(IUnitTypeRepository iRepository)
        {
            this.repository = iRepository;
        }

        public int Add(IEntity entity)
        {
            var newEntity = this.repository.Add((UnitType)entity);
            this.repository.Save();

            return newEntity.Id;
        }

        public void Edit(IEntity entity)
        {
            this.repository.Edit((UnitType)entity);
            this.repository.Save();
        }

        public void Delete(IEntity entity)
        {
            this.repository.Delete((UnitType)entity);
            this.repository.Save();
        }

        public IEntity FindById(object id)
        {
            return this.repository.FindById((int)id);
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

        public void Dispose()
        {

        }

    }
}