using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Repositories.Interfaces
{
    public interface ICartridgeLoadRepository : IRepository<CartridgeLoad>
    {
        List<Caliber> GetCalibers();

        List<CaliberView> GetCaliberViews();

        List<Bullet> GetBullets();

        List<BulletView> GetBulletViews();

        List<Powder> GetPowders();

        List<Unit> GetMassUnits();

        List<Unit> GetLengthUnits();

        List<Unit> GetVelocityUnits();

        List<Unit> GetPressureUnits();

        List<CartridgeLoadView> GetCartridgeLoadViews();
    }
}