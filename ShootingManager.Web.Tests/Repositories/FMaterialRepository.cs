using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Web.Tests.Repositories
{
    public static class FMaterialRepository
    {
        public static List<IEntity> AllMaterials
        {
            get
            {
                var materials = new List<IEntity>();
                var material = new Material();

                material.Id = 1;
                material.Name = "Test Material";
                materials.Add(material);

                return materials;
            }
        }
    }
}