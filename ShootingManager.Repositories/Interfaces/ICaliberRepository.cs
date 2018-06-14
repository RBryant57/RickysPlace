using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;

namespace ShootingManager.Repositories.Interfaces
{
    public interface ICaliberRepository : IRepository<Caliber>
    {
        List<PrimerType> GetPrimerTypes();

        List<Unit> GetLengthUnits();

        List<CaliberView> GetCaliberViews();
    }
}