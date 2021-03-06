﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Service.Interfaces
{
    public interface IBulletCostService : IDataService
    {
        List<Bullet> GetBullets();
        List<BulletView> GetBulletViews();
        List<Unit> GetQuantityUnits();
        List<UnitView> GetQuantityUnitViews();
    }
}