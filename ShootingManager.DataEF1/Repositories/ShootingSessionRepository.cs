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

namespace ShootingManager.EFData.Repositories
{
    public class ShootingSessionRepository : Repository<ShootingContext, ShootingSession>, IShootingSessionRepository
    {

        public List<ShootingLocation> GetShootingLocations()
        {
            return CommonRepository.GetShootingLocations(this.Context);
        }

        public List<Gun> GetGuns()
        {
            return CommonRepository.GetGuns(this.Context);
        }

        public List<Cartridge> GetCartridges()
        {
            return CommonRepository.GetCartridges(this.Context);
        }

        public List<ShootingSessionView> GetShootingSessionViews()
        {
            return this.Context.ShootingSessionViews.ToList();
        }

        public List<ShootingLocationView> GetShootingLocationViews()
        {
            return this.Context.ShootingLocationViews.ToList();
        }

        public override IQueryable<ShootingSession> GetAll()
        {
            return this.Context.ShootingSessions.Include("Cartridge").Include("Gun").Include("ShootingLocation");
        }

        public override ShootingSession FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }

    }
}