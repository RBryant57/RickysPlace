using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShootingManager.EFData.Mapping
{
    public partial class AddCheckConstraint : DbMigration
    {
        public override void Up()
        {
            this.CreateCheckConstraint("Products", "SKU", "SKU LIKE '[A-Z][A-Z]-[0-9][0-9]%'");
        }

        public override void Down()
        {
        }
    }
}