using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Service.Interfaces
{
    public interface IGunService : IDataService
    {
        List<Caliber> GetCalibers();
        List<Manufacturer> GetManufacturers();
        List<GunType> GetGunTypes();
        List<GunImage> GetGunImages();
        List<GunView> GetGunViews();
    }
}