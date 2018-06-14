using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Web.Tests.Repositories
{
    public static class FManufacturerRepository
    {
        public static List<IEntity> AllManufacturers
        {
            get
            {
                var manufacturers = new List<IEntity>();
                var manufacturer = new Manufacturer();

                manufacturer.Id = 1;
                manufacturer.Name = "Test Manufacturer";
                manufacturer.Address = "123 Any St.";
                manufacturer.City = "Test City";
                manufacturer.State = "WA";
                manufacturer.Zip = "12345";
                manufacturer.URL = "http://localhost:8000";
                manufacturers.Add(manufacturer);

                return manufacturers;
            }
        }
    }
}