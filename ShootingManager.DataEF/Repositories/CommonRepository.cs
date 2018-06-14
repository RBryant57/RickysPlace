using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShootingManager.Entities.Models;

namespace ShootingManager.DataEF
{
    public static class CommonRepository
    {
        public static List<Brass> GetBrasses(ShootingEntities context)
        {
            return context.Brasses.Include(c => c.Caliber).Include(m => m.Material).Include(m => m.Manufacturer).ToList();
        }

        public static List<Bullet> GetBullets(ShootingEntities context)
        {
            return context.Bullets.Include(b => b.BulletType).Include(m => m.Material).Include(m => m.Manufacturer).ToList();
        }

        public static List<BulletType> GetBulletTypes(ShootingEntities context)
        {
            return context.BulletTypes.ToList();
        }

        public static List<Caliber> GetCalibers(ShootingEntities context)
        {
            return context.Calibers.OrderBy(c => c.SortOrder).Include(p => p.PrimerType).ToList();
        }

        public static List<CartridgeLoad> GetCartridgeLoads(ShootingEntities context)
        {
            return context.CartridgeLoads.Include(c => c.Caliber).Include(c => c.Bullet).Include(p => p.Powder).ToList();
        }

        public static List<Cartridge> GetCartridges(ShootingEntities context)
        {
            return context.Cartridges.Include(c => c.CartridgeLoad).Include(b => b.Brass).Include(p => p.Primer).Include(m => m.Manufacturer).ToList();
        }

        public static List<Gun> GetGuns(ShootingEntities context)
        {
            return context.Guns.Include(c => c.Caliber).Include(m => m.Manufacturer).Include(s => s.Seller).Include(b => b.Buyer).Include(g => g.GunType).ToList();
        }

        public static List<GunType> GetGunTypes(ShootingEntities context)
        {
            return context.GunTypes.ToList();
        }

        public static List<InventoryType> GetInventoryTypes(ShootingEntities context)
        {
            return context.InventoryTypes.ToList();
        }

        public static List<Manufacturer> GetManufacturers(ShootingEntities context)
        {
            return context.Manufacturers.ToList();
        }

        public static List<Material> GetMaterials(ShootingEntities context)
        {
            return context.Materials.ToList();
        }

        public static List<Powder> GetPowders(ShootingEntities context)
        {
            return context.Powders.Include(m => m.Manufacturer).Include(p => p.PowderType).Include(p => p.PowderShape).ToList();
        }

        public static List<PowderShape> GetPowderShapes(ShootingEntities context)
        {
            return context.PowderShapes.ToList();
        }

        public static List<PowderType> GetPowderTypes(ShootingEntities context)
        {
            return context.PowderTypes.ToList();
        }

        public static List<Primer> GetPrimers(ShootingEntities context)
        {
            return context.Primers.Include(p => p.PrimerType).Include(m => m.Manufacturer).ToList();
        }

        public static List<PrimerType> GetPrimerTypes(ShootingEntities context)
        {
            return context.PrimerTypes.ToList();
        }

        public static List<ShootingLocation> GetShootingLocations(ShootingEntities context)
        {
            return context.ShootingLocations.ToList();
        }

        public static List<UnitType> GetUnitTypes(ShootingEntities context)
        {
            return context.UnitTypes.ToList();
        }

        public static List<Unit> GetLengthUnits(ShootingEntities context)
        {
            var length = from unit in context.Units
                         where unit.UnitType.Name.ToLower() == "length"
                         select unit;

            return length.ToList();
        }

        public static List<Unit> GetMassUnits(ShootingEntities context)
        {
            var mass = from unit in context.Units
                       where unit.UnitType.Name.ToLower() == "mass"
                       select unit;

            return mass.ToList();
        }

        public static List<Unit> GetPressureUnits(ShootingEntities context)
        {
            var mass = from unit in context.Units
                       where unit.UnitType.Name.ToLower() == "pressure"
                       select unit;

            return mass.ToList();
        }

        public static List<Unit> GetQuantityUnits(ShootingEntities context)
        {
            var quantity = from unit in context.Units
                         where unit.UnitType.Name.ToLower() == "quantity"
                         select unit;

            return quantity.ToList();
        }

        public static List<UnitView>GetQuantityUnitViews(ShootingEntities context)
        {
            var quantity = from unit in context.UnitViews
                           where unit.UnitTypeName.ToLower() == "quantity"
                           select unit;

            return quantity.ToList();
        }

        public static List<Unit> GetVelocityUnits(ShootingEntities context)
        {
            var length = from unit in context.Units
                         where unit.UnitType.Name.ToLower() == "velocity"
                         select unit;

            return length.ToList();
        }

    }
}