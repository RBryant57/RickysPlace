using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using Data.Core.Repositories;
using ShootingManager.Entities.Models;
using ShootingManager.Repositories.Interfaces;

namespace ShootingManager.DataEF.Repositories
{
    public class UnitRepository : Repository<ShootingEntities, Unit>, IUnitRepository
    {
        public List<UnitType> GetUnitTypes()
        {
            return CommonRepository.GetUnitTypes(this.Context);
        }

        public List<UnitView> GetUnitViews()
        {
            return this.Context.UnitViews.ToList();
        }

        public override IQueryable<Unit> GetAll()
        {
            return this.Context.Units.Include("Brasses").Include("BrassCosts").Include("BrassQuantities").Include("DiameterUnitBullets").Include("LengthUnitBullets").Include("MassUnitBullets").Include("BulletCosts").Include("BulletQuantities").Include("Calibers").Include("PowderWeightUnitCartridgeLoads").Include("COLUnitCartridgeLoads").Include("VelocityUnitCartridgeLoads").Include("PressureUnitCartridgeLoads").Include("CartridgeQuantities").Include("PowderCosts").Include("PowderQuantities").Include("PrimerCosts").Include("PrimerQuantities").Include("UnitType");
        }

        public override Unit FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }

    }
}