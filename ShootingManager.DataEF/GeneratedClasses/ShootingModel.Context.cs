﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShootingManager.DataEF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShootingEntities : DbContext
    {
        public ShootingEntities()
            : base("name=ShootingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Brass> Brasses { get; set; }
        public virtual DbSet<BrassCost> BrassCosts { get; set; }
        public virtual DbSet<BrassQuantity> BrassQuantities { get; set; }
        public virtual DbSet<Bullet> Bullets { get; set; }
        public virtual DbSet<BulletCost> BulletCosts { get; set; }
        public virtual DbSet<BulletQuantity> BulletQuantities { get; set; }
        public virtual DbSet<BulletType> BulletTypes { get; set; }
        public virtual DbSet<Caliber> Calibers { get; set; }
        public virtual DbSet<Cartridge> Cartridges { get; set; }
        public virtual DbSet<CartridgeCost> CartridgeCosts { get; set; }
        public virtual DbSet<CartridgeLoad> CartridgeLoads { get; set; }
        public virtual DbSet<CartridgeQuantity> CartridgeQuantities { get; set; }
        public virtual DbSet<Gun> Guns { get; set; }
        public virtual DbSet<GunImage> GunImages { get; set; }
        public virtual DbSet<GunsCaliber> GunsCalibers { get; set; }
        public virtual DbSet<GunType> GunTypes { get; set; }
        public virtual DbSet<InventoryType> InventoryTypes { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Powder> Powders { get; set; }
        public virtual DbSet<PowderCost> PowderCosts { get; set; }
        public virtual DbSet<PowderQuantity> PowderQuantities { get; set; }
        public virtual DbSet<PowderShape> PowderShapes { get; set; }
        public virtual DbSet<PowderType> PowderTypes { get; set; }
        public virtual DbSet<Primer> Primers { get; set; }
        public virtual DbSet<PrimerCost> PrimerCosts { get; set; }
        public virtual DbSet<PrimerQuantity> PrimerQuantities { get; set; }
        public virtual DbSet<PrimerType> PrimerTypes { get; set; }
        public virtual DbSet<ShootingLocation> ShootingLocations { get; set; }
        public virtual DbSet<ShootingSession> ShootingSessions { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<UnitType> UnitTypes { get; set; }
        public virtual DbSet<BrassView> BrassViews { get; set; }
        public virtual DbSet<BulletView> BulletViews { get; set; }
        public virtual DbSet<CaliberView> CaliberViews { get; set; }
        public virtual DbSet<CartridgeLoadView> CartridgeLoadViews { get; set; }
        public virtual DbSet<CartridgeView> CartridgeViews { get; set; }
        public virtual DbSet<GunsCalibersView> GunsCalibersViews { get; set; }
        public virtual DbSet<GunView> GunViews { get; set; }
        public virtual DbSet<PowderView> PowderViews { get; set; }
        public virtual DbSet<PrimerView> PrimerViews { get; set; }
        public virtual DbSet<ShootingLocationView> ShootingLocationViews { get; set; }
        public virtual DbSet<ShootingSessionView> ShootingSessionViews { get; set; }
        public virtual DbSet<UnitView> UnitViews { get; set; }
    }
}
