using Microsoft.AspNet.Identity.EntityFramework;

namespace ShootingManager.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        //public System.Data.Entity.DbSet<ShootingManager.Web.ShootingContextService.UnitType> UnitTypes { get; set; }

        //public System.Data.Entity.DbSet<ShootingManager.Web.ShootingContextService.Brass> Brasses { get; set; }

        //public System.Data.Entity.DbSet<ShootingManager.Web.ShootingContextService.Caliber> Calibers { get; set; }

        //public System.Data.Entity.DbSet<ShootingManager.Web.ShootingContextService.Manufacturer> Manufacturers { get; set; }

        //public System.Data.Entity.DbSet<ShootingManager.Web.ShootingContextService.Material> Materials { get; set; }
    }
}