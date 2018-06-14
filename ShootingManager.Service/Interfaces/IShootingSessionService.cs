using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Service.Interfaces
{
    public interface IShootingSessionService : IDataService
    {

        List<ShootingLocation> GetShootingLocations();
        List<Gun> GetGuns();
        List<Cartridge> GetCartridges();
        List<ShootingSessionView> GetShootingSessionViews();
        List<ShootingLocationView> GetShootingLocationViews();

    }
}