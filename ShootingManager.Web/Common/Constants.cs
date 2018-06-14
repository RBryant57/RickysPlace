using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShootingManager.Web.Common
{
    public static class Constants
    {
        public const string LENGTH_QUERY = "SELECT * FROM Unit INNER JOIN UnitType ON Unit.UnitTypeId = UnitType.Id WHERE UnitType.Name LIKE 'length'";
        public const string MASS_QUERY = "SELECT * FROM Unit INNER JOIN UnitType ON Unit.UnitTypeId = UnitType.Id WHERE UnitType.Name LIKE 'mass'";
        public const string PRESSURE_QUERY = "SELECT * FROM Unit INNER JOIN UnitType ON Unit.UnitTypeId = UnitType.Id WHERE UnitType.Name LIKE 'pressure'";
        public const string CALIBER_BULLET_QUERY = "SELECT Caliber.* FROM BulletsCalibers INNER JOIN Caliber ON BulletsCalibers.CaliberId = Caliber.Id WHERE BulletsCalibers.BulletId =";
    }
}