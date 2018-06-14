using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Repositories;
using ShootingManager.Entities.Models;
using ShootingManager.Repositories.Interfaces;

namespace ShootingManager.DataEF.Repositories
{
    public class CaliberCalibersRepository : Repository<ShootingEntities, CaliberCalibers>, ICaliberCalibersRepository
    {
        //public override IQueryable<CaliberCalibers> GetAll()
        //{
        //    return this.Context.CaliberCalibers.Include("Calibers").Include("Calibers");
        //}

        public override CaliberCalibers FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }

        //public override GunsCalibers Add(GunsCalibers entity)
        //{
        //    var ret = this.Context.GunsCalibers.SqlQuery("INSERT INTO GunsCalibers VALUES(" + entity.GunId + ", " + entity.CaliberId + ")");//;SELECT @@IDENTITY AS 'Id'," + entity.GunId + " AS 'GunId'," + entity.CaliberId + " AS 'CaliberId'");

        //    return entity;
        //}

    }
}