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
    public class CaliberService : ICaliberService
    {
        private ICaliberRepository repository;
        private ICaliberCalibersRepository caliberCalibersRepository;

        public CaliberService()
        {
            this.repository = new CaliberRepository();
            this.caliberCalibersRepository = new CaliberCalibersRepository();
        }

        public CaliberService(ICaliberRepository iRepository, ICaliberCalibersRepository icaliberCalibersRepository)
        {
            this.repository = iRepository;
            this.caliberCalibersRepository = icaliberCalibersRepository;
        }

        public int Add(IEntity entity)
        {
            var newEntity = this.repository.Add((Caliber)entity);
            this.repository.Save();

            return newEntity.Id;
        }

        public void Edit(IEntity entity)
        {
            this.repository.Edit((Caliber)entity);
            this.repository.Save();
        }

        public void Delete(IEntity entity)
        {
            this.repository.Delete((Caliber)entity);
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

        public List<PrimerType> GetPrimerTypes()
        {
            return this.repository.GetPrimerTypes();
        }

        public List<Unit> GetLengthUnits()
        {
            return this.repository.GetLengthUnits();
        }

        public List<CaliberView> GetCaliberViews()
        {
            return this.repository.GetCaliberViews();
        }

        public List<CaliberCalibers> GetCaliberCalibers()
        {
            return this.caliberCalibersRepository.GetAll().ToList();
        }

        public int AddCaliberCalibers(CaliberCalibers caliberCalibers)
        {
            return this.caliberCalibersRepository.Add(caliberCalibers).Id;
        }

        public void DeleteCaliberCalibers(CaliberCalibers caliberCalibers)
        {
            this.caliberCalibersRepository.Delete(caliberCalibers);
        }

        public void Dispose()
        {

        }
    }
}