using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingManager.EFData.Mapping
{
    public static class DbMigrationExtensions
    {
        public static void CreateCheckConstraint(this DbMigration migration, string table, string column, string checkConstraint)
        {
            var createCheckConstraint = new CreateCheckConstraintOperation
            {
                Table = table,
                Column = column,
                CheckConstraint = checkConstraint
            };

            ((IDbMigration)migration).AddOperation(createCheckConstraint);
        }
    }
}
