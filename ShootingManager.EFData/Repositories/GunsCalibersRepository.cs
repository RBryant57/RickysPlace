using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Repositories;
using ShootingManager.Entities.Models;
using ShootingManager.Repositories.Interfaces;

namespace ShootingManager.EFData.Repositories
{
    public class GunsCalibersRepository : Repository<ShootingContext1, GunsCalibers>, IGunsCalibersRepository
    {
        public override IQueryable<GunsCalibers> GetAll()
        {
            return this.Context.GunsCalibers.Include("Guns").Include("Calibers");
        }

        public override GunsCalibers FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }

        public override GunsCalibers Add(GunsCalibers entity)
        {
            var ret = this.Context.GunsCalibers.SqlQuery("INSERT INTO GunsCalibers VALUES(" + entity.GunId + ", " + entity.CaliberId + ")");//;SELECT @@IDENTITY AS 'Id'," + entity.GunId + " AS 'GunId'," + entity.CaliberId + " AS 'CaliberId'");

            return entity;
        }

        public List<GunsCalibersView> GetGunsCalibersViews()
        {
            return this.Context.GunsCalibersView.ToList();
        }
    }
}