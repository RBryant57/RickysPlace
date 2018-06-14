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
    public class BrassCostService : IBrassCostService
    {
        //private IBrassCostRepository repository;
        //private IBrassRepository brassRepository;
        //private IUnitRepository unitRepository;

        //public BrassCostService()
        //{
        //    this.repository = new BrassCostRepository();
        //    this.brassRepository = new BrassRepository();
        //    this.unitRepository = new UnitRepository();
        //}

        //public BrassCostService(IBrassCostRepository iRepository, IBrassRepository iBrassRepository, IUnitRepository iUnitRepository)
        //{
        //    this.repository = iRepository;
        //    this.brassRepository = iBrassRepository;
        //    this.unitRepository = iUnitRepository;
        //}

        //public void Add(IEntity entity)
        //{
        //    this.repository.Add((BrassCost)entity);
        //    this.repository.Save();
        //}

        //public void Edit(IEntity entity)
        //{
        //    this.repository.Edit((BrassCost)entity);
        //    this.repository.Save();
        //}

        //public void Delete(IEntity entity)
        //{
        //    this.repository.Refresh();

        //    this.repository.Delete((BrassCost)entity);
        //    this.repository.Save();
        //}

        //public IEntity FindById(object id)
        //{
        //    return this.repository.FindById(id);
        //}

        //public List<IEntity> GetAll()
        //{
        //    var list = new List<IEntity>();
        //    foreach (BrassCost entity in this.repository.GetAll())
        //    {
        //        list.Add(entity);
        //    }

        //    return list;
        //}

        //public List<Brass> GetBrasses()
        //{
        //    return this.brassRepository.GetAll().OfType<Brass>().ToList();
        //}

        //public List<BrassView> GetBrassViews()
        //{
        //    return this.brassRepository.GetBrassViews();
        //}

        //public List<Unit> GetQuantityUnits()
        //{
        //    return this.repository.GetQuantityUnits();
        //}

        //public List<UnitView> GetQuantityUnitViews()
        //{
        //    return this.unitRepository.GetUnitViews();
        //}

        //public void Dispose()
        //{
   
        //}

    }
}