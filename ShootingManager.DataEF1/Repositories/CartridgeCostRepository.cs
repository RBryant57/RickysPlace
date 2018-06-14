﻿using System;
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
    public class CartridgeCostRepository : Repository<ShootingContext, CartridgeCost>, ICartridgeCostRepository
    {
        public override IQueryable<CartridgeCost> GetAll()
        {
            return this.Context.CartridgeCosts.Include("Cartridge").Include("QuantityUnit");
        }

        public override CartridgeCost FindById(object id)
        {
            return this.GetAll().Where(e => e.Id == (int)id).First();
        }

    }
}