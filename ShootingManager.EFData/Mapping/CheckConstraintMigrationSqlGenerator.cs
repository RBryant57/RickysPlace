using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingManager.EFData.Mapping
{
    public class CheckConstraintMigrationSqlGenerator : SqlServerMigrationSqlGenerator
    {
        protected override void Generate(MigrationOperation migrationOperation)
        {
            var checkConstraintOperation = migrationOperation as CreateCheckConstraintOperation;

            if (checkConstraintOperation != null)
            {
                if (checkConstraintOperation.CheckConstraintName == null)
                {
                    checkConstraintOperation.CheckConstraintName = checkConstraintOperation.BuildDefaultName();
                }

                using (var writer = Writer())
                {
                    writer.WriteLine(
                        "ALTER TABLE {0} ADD CONSTRAINT {1} CHECK ({2})",
                        Name(checkConstraintOperation.Table),
                        Quote(checkConstraintOperation.CheckConstraintName),
                        checkConstraintOperation.CheckConstraint
                    );
                    Statement(writer);
                }
            }
        }
    }
}
