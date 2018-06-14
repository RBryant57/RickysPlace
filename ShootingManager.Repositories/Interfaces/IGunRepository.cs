using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Repositories.Interfaces
{
    public interface IGunRepository : IRepository<Gun>
    {
        List<Caliber> GetCalibers();
        List<Manufacturer> GetManufacturers();
        List<GunType> GetGunTypes();
        List<GunImage> GetGunImages();
        List<GunView> GetGunViews();
        void InsertGunImage(GunImage image);
    }
}