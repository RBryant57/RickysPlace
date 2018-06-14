using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;
using ShootingManager.Service;
using ShootingManager.Service.Interfaces;

namespace ShootingManager.Web.Common
{
    public class EntityLoader
    {
        public static List<Manufacturer> GetManufacturers()
        {
            var entityService = new ManufacturerService();
            var results = entityService.GetAll().OfType<Manufacturer>().OrderBy(m => m.Name).ToList();

            return results;
        }

        public static List<Manufacturer> GetManufacturers(IManufacturerService entityService)
        {
            var results = entityService.GetAll().OfType<Manufacturer>().OrderBy(m => m.Name).ToList();

            return results;
        }

        public static List<Material> GetMaterials()
        {
            var entityService = new MaterialService();
            var results = entityService.GetAll().OfType<Material>().OrderBy(m => m.Name).ToList();

            return results;
        }
        public static List<Material> GetMaterials(IMaterialService entityService)
        {
            var results = entityService.GetAll().OfType<Material>().OrderBy(m => m.Name).ToList();

            return results;
        }
    }
}
