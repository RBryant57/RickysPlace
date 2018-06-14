using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using ShootingManager.EFData.Mapping;
using ShootingManager.Entities.Models;

namespace ShootingManager.EFData
{
    public partial class ShootingContext1 : DbContext
    {
        static ShootingContext1()
        {
            Database.SetInitializer<ShootingContext1>(null);
        }

        public ShootingContext1()
            : base("Name=ShootingContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Brass> Brasses { get; set; }
        public DbSet<BrassCost> BrassCosts { get; set; }
        public DbSet<BrassQuantity> BrassQuantities { get; set; }
        public DbSet<Bullet> Bullets { get; set; }
        public DbSet<BulletCost> BulletCosts { get; set; }
        public DbSet<BulletQuantity> BulletQuantities { get; set; }
        public DbSet<BulletType> BulletTypes { get; set; }
        public DbSet<Caliber> Calibers { get; set; }
        public DbSet<Cartridge> Cartridges { get; set; }
        public DbSet<CartridgeLoad> CartridgeLoads { get; set; }
        public DbSet<CartridgeQuantity> CartridgeQuantities { get; set; }
        public DbSet<CartridgeCost> CartridgeCosts { get; set; }
        public DbSet<Gun> Guns { get; set; }
        public DbSet<GunImage> GunImages { get; set; }
        public DbSet<GunType> GunTypes { get; set; }
        public DbSet<InventoryType> InventoryTypes { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Powder> Powders { get; set; }
        public DbSet<PowderCost> PowderCosts { get; set; }
        public DbSet<PowderQuantity> PowderQuantities { get; set; }
        public DbSet<PowderShape> PowderShapes { get; set; }
        public DbSet<PowderType> PowderTypes { get; set; }
        public DbSet<Primer> Primers { get; set; }
        public DbSet<PrimerCost> PrimerCosts { get; set; }
        public DbSet<PrimerQuantity> PrimerQuantities { get; set; }
        public DbSet<PrimerType> PrimerTypes { get; set; }
        public DbSet<ShootingLocation> ShootingLocations { get; set; }
        public DbSet<ShootingSession> ShootingSessions { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<UnitType> UnitTypes { get; set; }
        public DbSet<BrassView> BrassViews { get; set; }
        public DbSet<BulletView> BulletViews { get; set; }
        public DbSet<CartridgeView> CartridgeViews { get; set; }
        public DbSet<CartridgeLoadView> CartridgeLoadViews { get; set; }
        public DbSet<PowderView> PowderViews { get; set; }
        public DbSet<PrimerView> PrimerViews { get; set; }
        public DbSet<CaliberView> CaliberViews { get; set; }
        public DbSet<GunView> GunViews { get; set; }
        public DbSet<GunsCalibersView> GunsCalibersView {get;set;}
        public DbSet<UnitView> UnitViews { get; set; }
        public DbSet<ShootingSessionView> ShootingSessionViews { get; set; }
        public DbSet<ShootingLocationView> ShootingLocationViews { get; set; }
        public DbSet<GunsCalibers> GunsCalibers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caliber>().Property(caliber => caliber.Diameter).HasPrecision(7, 3);

            modelBuilder.Configurations.Add(new BrassMap());
            modelBuilder.Configurations.Add(new BrassCostMap());
            modelBuilder.Configurations.Add(new BrassQuantityMap());
            modelBuilder.Configurations.Add(new BulletMap());
            modelBuilder.Configurations.Add(new BulletCostMap());
            modelBuilder.Configurations.Add(new BulletQuantityMap());
            modelBuilder.Configurations.Add(new BulletTypeMap());
            modelBuilder.Configurations.Add(new CaliberMap());
            modelBuilder.Configurations.Add(new CartridgeMap());
            modelBuilder.Configurations.Add(new CartridgeLoadMap());
            modelBuilder.Configurations.Add(new CartridgeQuantityMap());
            modelBuilder.Configurations.Add(new CartridgeCostMap());
            modelBuilder.Configurations.Add(new GunMap());
            modelBuilder.Configurations.Add(new GunImageMap());
            modelBuilder.Configurations.Add(new GunTypeMap());
            modelBuilder.Configurations.Add(new InventoryTypeMap());
            modelBuilder.Configurations.Add(new ManufacturerMap());
            modelBuilder.Configurations.Add(new MaterialMap());
            modelBuilder.Configurations.Add(new PowderMap());
            modelBuilder.Configurations.Add(new PowderCostMap());
            modelBuilder.Configurations.Add(new PowderQuantityMap());
            modelBuilder.Configurations.Add(new PowderShapeMap());
            modelBuilder.Configurations.Add(new PowderTypeMap());
            modelBuilder.Configurations.Add(new PrimerMap());
            modelBuilder.Configurations.Add(new PrimerCostMap());
            modelBuilder.Configurations.Add(new PrimerQuantityMap());
            modelBuilder.Configurations.Add(new PrimerTypeMap());
            modelBuilder.Configurations.Add(new ShootingLocationMap());
            modelBuilder.Configurations.Add(new ShootingSessionMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UnitMap());
            modelBuilder.Configurations.Add(new UnitTypeMap());
            modelBuilder.Configurations.Add(new BrassViewMap());
            modelBuilder.Configurations.Add(new BulletViewMap());
            modelBuilder.Configurations.Add(new CartridgeViewMap());
            modelBuilder.Configurations.Add(new CartridgeLoadViewMap());
            modelBuilder.Configurations.Add(new PowderViewMap());
            modelBuilder.Configurations.Add(new PrimerViewMap());
            modelBuilder.Configurations.Add(new CaliberViewMap());
            modelBuilder.Configurations.Add(new GunViewMap());
            modelBuilder.Configurations.Add(new UnitViewMap());
            modelBuilder.Configurations.Add(new ShootingSessionViewMap());
            modelBuilder.Configurations.Add(new ShootingLocationViewMap());
            modelBuilder.Configurations.Add(new GunsCalibersMap());
            modelBuilder.Configurations.Add(new GunsCalibersViewMap());

        }
    }
}
