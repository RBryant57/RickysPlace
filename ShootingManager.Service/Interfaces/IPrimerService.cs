using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Service.Interfaces
{
    public interface IPrimerService : IDataService, IManagementService
    {
        List<PrimerView> GetAllQuantityViewsWithNoInventory();
        List<PrimerType> GetPrimerTypes();
        List<PrimerView> GetPrimerViews();
        List<Cartridge> GetCartridges();
        List<Manufacturer> GetManufacturers();

    }
}