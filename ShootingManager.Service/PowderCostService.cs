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
    public class PowderCostService : IPowderCostService
    {
        private IPowderCostRepository repository;
        private IPowderRepository powderRepository;
        private IUnitRepository unitRepository;

        public PowderCostService()
        {
            this.repository = new PowderCostRepository();
            this.powderRepository = new PowderRepository();
            this.unitRepository = new UnitRepository();
        }

        public PowderCostService(IPowderCostRepository iRepository, IPowderRepository iPowderRepository, IUnitRepository iUnitRepository)
        {
            this.repository = iRepository;
            this.powderRepository = iPowderRepository;
            this.unitRepository = iUnitRepository;
        }

        public void Add(IEntity entity)
        {
            this.repository.Add((PowderCost)entity);
            this.repository.Save();
        }

        public void Edit(IEntity entity)
        {
            this.repository.Edit((PowderCost)entity);
            this.repository.Save();
        }

        public void Delete(IEntity entity)
        {
            this.repository.Refresh();

            this.repository.Delete((PowderCost)entity);
            this.repository.Save();
        }

        public IEntity FindById(object id)
        {
            return this.repository.FindById(id);
        }

        public List<IEntity> GetAll()
        {
            var list = new List<IEntity>();
            foreach (PowderCost entity in this.repository.GetAll())
            {
                list.Add(entity);
            }

            return list;
        }

        public List<Powder> GetPowders()
        {
            return this.powderRepository.GetAll().OfType<Powder>().ToList();
        }

        public List<PowderView> GetPowderViews()
        {
            return this.powderRepository.GetPowderViews();
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