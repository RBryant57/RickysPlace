﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Repositories;
using ShootingManager.Entities.Models;
using ShootingManager.Repositories.Interfaces;

namespace ShootingManager.EFData.Repositories
{
    public class BulletTypeRepository : Repository<ShootingContext, BulletType>, IBulletTypeRepository
    {
        public override IQueryable<BulletType> GetAll()
        {
            return this.Context.BulletTypes.Include("Bullets");
        }

        public override BulletType FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }
    }
}