using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Repositories;
using ShootingManager.Entities.Models;
using ShootingManager.Repositories.Interfaces;

namespace ShootingManager.EFData.Repositories
{
    public class CaliberRepository : Repository<ShootingContext, Caliber>, ICaliberRepository
    {
        public List<PrimerType> GetPrimerTypes()
        {
            return CommonRepository.GetPrimerTypes(this.Context);
        }

        public List<Unit> GetLengthUnits()
        {
            return CommonRepository.GetLengthUnits(this.Context);
        }

        public List<CaliberView> GetCaliberViews()
        {
            return this.Context.CaliberViews.ToList();
        }

        public override IQueryable<Caliber> GetAll()
        {
            return this.Context.Calibers.Include("Brasses").Include("Guns").Include("CartridgeLoads").Include("Unit").Include("PrimerType");
        }

        public override Caliber FindById(object id)
        {
            return this.Context.Calibers.Include("Brasses").Include("Guns").Include("CartridgeLoads").Include("Unit").Include("PrimerType").Where(e => e.Id == (int)id).First();
        }
    }
}