using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

using Data.Core.Interfaces;
using ShootingManager.Entities.Models;
using ShootingManager.Service;
using Web.Core;

namespace ShootingManager.Web.Controllers
{
    public class ShootingManagerBaseController : BaseController
    {
        protected IEnumerable<IEntity> brasses;
        protected IEnumerable<BrassView> brassViews;
        protected IEnumerable<BrassQuantity> brassQuantities;
        protected IEnumerable<IEntity> bullets;
        protected IEnumerable<IEntity> bulletTypes;
        protected IEnumerable<BulletView> bulletViews;
        protected IEnumerable<BulletQuantity> bulletQuantities;
        protected IEnumerable<IEntity> calibers;
        protected IEnumerable<CaliberView> caliberViews;
        protected IEnumerable<IEntity> cartridges;
        protected IEnumerable<CartridgeQuantity> cartridgeQuantities;
        protected IEnumerable<IEntity> cartridgeLoads;
        protected IEnumerable<CartridgeView> cartridgeViews;
        protected IEnumerable<CartridgeLoadView> cartridgeLoadViews;
        protected IEnumerable<IEntity> guns;
        protected IEnumerable<IEntity> gunTypes;
        protected IEnumerable<GunView> gunViews;
        protected IEnumerable<InventoryType> inventoryTypes;
        protected IEnumerable<IEntity> lengthUnits;
        protected IEnumerable<IEntity> manufacturers;
        protected IEnumerable<IEntity> massUnits;
        protected IEnumerable<IEntity> materials;
        protected IEnumerable<IEntity> powders;
        protected IEnumerable<IEntity> powderShapes;
        protected IEnumerable<IEntity> powderTypes;
        protected IEnumerable<PowderView> powderViews;
        protected IEnumerable<PowderQuantity> powderQuantities;
        protected IEnumerable<IEntity> pressureUnits;
        protected IEnumerable<IEntity> primers;
        protected IEnumerable<IEntity> primerTypes;
        protected IEnumerable<PrimerView> primerViews;
        protected IEnumerable<PrimerQuantity> primerQuantities;
        protected IEnumerable<IEntity> quantityUnits;
        protected IEnumerable<IEntity> shootingLocations;
        protected IEnumerable<ShootingLocationView> shootingLocationViews;
        protected IEnumerable<IEntity> shootingSessions;
        protected IEnumerable<ShootingSessionView> shootingSessionViews;
        protected IEnumerable<IEntity> unitTypes;
        protected IEnumerable<IEntity> velocityUnits;

        private CartridgeService cartridgeService = new CartridgeService();
        private CartridgeLoadService cartridgeLoadService = new CartridgeLoadService();
        private BulletService bulletService = new BulletService();
        private BrassService brassService = new BrassService();
        private GunService gunService = new GunService();
        private PowderService powderService = new PowderService();
        private PrimerService primerService = new PrimerService();
        private ShootingSessionService shootingSessionService = new ShootingSessionService();
        private UnitTypeService unitTypeService = new UnitTypeService();

        public ShootingManagerBaseController()
        { 
            this.brasses = cartridgeService.GetBrasses().OfType<Brass>().OrderBy(b => b.Name);
            this.brassViews = cartridgeService.GetBrassViews().OrderBy(b => b.BrassName);
            this.brassQuantities = brassService.GetAllQuantities().OfType<BrassQuantity>();
            this.bullets = cartridgeLoadService.GetBullets().OfType<Bullet>().OrderBy(b => b.Name);
            this.bulletTypes = bulletService.GetBulletTypes().OfType<BulletType>().OrderBy(b => b.Abbreviation);
            this.bulletViews = bulletService.GetBulletViews().OrderBy(b => b.BulletName);
            this.bulletQuantities = bulletService.GetAllQuantities().OfType<BulletQuantity>();
            this.calibers = cartridgeLoadService.GetCalibers().OfType<Caliber>().OrderBy(c => c.SortOrder);
            this.caliberViews = cartridgeLoadService.GetCaliberViews().OrderBy(c => c.SortOrder);
            this.cartridges = cartridgeService.GetAll().OfType<Cartridge>().OrderBy(c => c.CartridgeLoad.Caliber.SortOrder).ThenBy(c => c.Name);
            this.cartridgeQuantities = cartridgeService.GetAllQuantities().OfType<CartridgeQuantity>();
            this.cartridgeLoads = cartridgeLoadService.GetAll().OfType<CartridgeLoad>().OrderBy(c => c.Caliber.SortOrder).ThenBy(c => c.Name);
            this.cartridgeViews = cartridgeService.GetCartridgeViews().OrderBy(c => c.CartridgeLoadViewCaliberViewSortOrder).ThenBy(c => c.Name);
            this.cartridgeLoadViews = cartridgeLoadService.GetCartridgeLoadViews().OrderBy(c => c.CaliberViewSortOrder).ThenBy(c => c.Name);
            this.guns = gunService.GetAll().OfType<Gun>().OrderBy(g => g.Name);
            this.gunTypes = gunService.GetGunTypes().OfType<GunType>().OrderBy(g => g.Name);
            this.gunViews = gunService.GetGunViews().OrderBy(g => g.Name);
            this.inventoryTypes = brassService.GetInventoryTypes().OfType<InventoryType>().OrderBy(i => i.Description);
            this.lengthUnits = cartridgeLoadService.GetLengthUnits().OfType<Unit>().OrderBy(l => l.Name);
            this.manufacturers = cartridgeService.GetManufacturers().OfType<Manufacturer>().OrderBy(m => m.Name);
            this.massUnits = cartridgeLoadService.GetMassUnits().OfType<Unit>().OrderBy(m => m.Name);
            this.materials = bulletService.GetMaterials().OfType<Material>().OrderBy(m => m.Name);
            this.powders = cartridgeLoadService.GetPowders().OfType<Powder>().OrderBy(p => p.Name);
            this.powderShapes = powderService.GetPowderShapes().OfType<PowderShape>().OrderBy(p => p.Name);
            this.powderTypes = powderService.GetPowderTypes().OfType<PowderType>().OrderBy(p => p.Name);
            this.powderViews = powderService.GetPowderViews().OrderBy(p => p.Name);
            this.powderQuantities = powderService.GetAllQuantities().OfType<PowderQuantity>();
            this.pressureUnits = cartridgeLoadService.GetPressureUnits().OfType<Unit>().OrderBy(p => p.Name);
            this.primers = cartridgeService.GetPrimers().OfType<Primer>().OrderBy(p => p.Name);
            this.primerTypes = primerService.GetPrimerTypes().OrderBy(p => p.Name);
            this.primerViews = primerService.GetPrimerViews().OrderBy(p => p.PrimerName);
            this.primerQuantities = primerService.GetAllQuantities().OfType<PrimerQuantity>();
            this.quantityUnits = brassService.GetQuantityUnits().OfType<Unit>().OrderBy(q => q.Name);
            this.shootingLocations = shootingSessionService.GetShootingLocations().OfType<ShootingLocation>().OrderBy(s => s.Name);
            this.shootingLocationViews = shootingSessionService.GetShootingLocationViews().OrderBy(s => s.ShootingLocationName);
            this.shootingSessions = shootingSessionService.GetAll().OfType<ShootingSession>().OrderBy(s => s.Date);
            this.shootingSessionViews = shootingSessionService.GetShootingSessionViews().OrderBy(s => s.Date);
            this.unitTypes = unitTypeService.GetAll().OfType<UnitType>().OrderBy(u => u.Name);
            this.velocityUnits = cartridgeLoadService.GetVelocityUnits().OfType<Unit>().OrderBy(v => v.Name);
        }

        public ShootingManagerBaseController(IDataService entityService)
        {
            var assembly = Assembly.LoadFile("...ShootingManager.Service.dll");
            var type = entityService.GetType();

            var method = type.GetMethod("GetBrasses");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.brasses = method.Invoke(classInstance, null) as List<Brass>;
            }

            method = type.GetMethod("GetBrassViews");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.brassViews = method.Invoke(classInstance, null) as List<BrassView>;
            }

            method = type.GetMethod("GetBrassQuantities");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.brassQuantities = method.Invoke(classInstance, null) as List<BrassQuantity>;
            }

            method = type.GetMethod("GetBullets");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.bullets = method.Invoke(classInstance, null) as List<Bullet>;
            }

            method = type.GetMethod("GetBulletTypes");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.bulletTypes = method.Invoke(classInstance, null) as List<BulletType>;
            }

            method = type.GetMethod("GetBulletViews");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.bulletViews = method.Invoke(classInstance, null) as List<BulletView>;
            }

            method = type.GetMethod("GetBulletQuantities");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.bulletQuantities = method.Invoke(classInstance, null) as List<BulletQuantity>;
            }

            method = type.GetMethod("GetCalibers");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.calibers = method.Invoke(classInstance, null) as List<Caliber>;
            }

            method = type.GetMethod("GetCaliberViews");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.caliberViews = method.Invoke(classInstance, null) as List<CaliberView>;
            }

            method = type.GetMethod("GetCartridges");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.cartridges = method.Invoke(classInstance, null) as List<Cartridge>;
            }

            method = type.GetMethod("GetGuns");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.guns = method.Invoke(classInstance, null) as List<Gun>;
            }

            method = type.GetMethod("GetGunTypes");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.gunTypes = method.Invoke(classInstance, null) as List<GunType>;
            }

            method = type.GetMethod("GetGunViews");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.gunViews = method.Invoke(classInstance, null) as List<GunView>;
            }

            method = type.GetMethod("GetInventoryTypes");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.inventoryTypes = method.Invoke(classInstance, null) as List<InventoryType>;
            }


            method = type.GetMethod("GetLengthUnits");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.lengthUnits = method.Invoke(classInstance, null) as List<Unit>;
            }

            method = type.GetMethod("GetManufacturers");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.manufacturers = method.Invoke(classInstance, null) as List<Manufacturer>;
            }

            method = type.GetMethod("GetMassUnits");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.massUnits = method.Invoke(classInstance, null) as List<Unit>;
            }

            method = type.GetMethod("GetMaterials");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.materials = method.Invoke(classInstance, null) as List<Material>;
            }

            method = type.GetMethod("GetQuantityUnits");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.quantityUnits = method.Invoke(classInstance, null) as List<Unit>;
            }

            method = type.GetMethod("GetPowders");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.powders = method.Invoke(classInstance, null) as List<Powder>;
            }

            method = type.GetMethod("GetPowderShapes");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.powderShapes = method.Invoke(classInstance, null) as List<PowderShape>;
            }

            method = type.GetMethod("GetPowderTypes");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.powderTypes = method.Invoke(classInstance, null) as List<PowderType>;
            }

            method = type.GetMethod("GetPowderViews");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.powderViews = method.Invoke(classInstance, null) as List<PowderView>;
            }

            method = type.GetMethod("GetPowderQuantities");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.powderQuantities = method.Invoke(classInstance, null) as List<PowderQuantity>;
            }

            method = type.GetMethod("GetPrimers");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.primers = method.Invoke(classInstance, null) as List<Primer>;
            }

            method = type.GetMethod("GetPrimerTypes");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.primerTypes = method.Invoke(classInstance, null) as List<PrimerType>;
            }

            method = type.GetMethod("GetPrimerViews");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.primerViews = method.Invoke(classInstance, null) as List<PrimerView>;
            }

            method = type.GetMethod("GetPrimerQuantities");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.primerQuantities = method.Invoke(classInstance, null) as List<PrimerQuantity>;
            }

            method = type.GetMethod("GetShootingLocations");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.shootingLocations = method.Invoke(classInstance, null) as List<ShootingLocation>;
            }

            method = type.GetMethod("GetShootingSessions");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.shootingSessions = method.Invoke(classInstance, null) as List<ShootingSession>;
            }

            method = type.GetMethod("GetUnitTypes");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.unitTypes = method.Invoke(classInstance, null) as List<UnitType>;
            }

            method = type.GetMethod("GetVelocityUnits");
            if (method != null)
            {
                var classInstance = Activator.CreateInstance(type, null);
                this.velocityUnits = method.Invoke(classInstance, null) as List<Unit>;
            }
        }

        protected bool addFactoryCartridge(Brass brass, Bullet bullet, CartridgeLoad cartridgeLoad, bool addToStore)
        {
            try
            {
                using (var transaction = new TransactionScope())
                {
                    int brassId;
                    if (this.brasses.OfType<Brass>().Where(b => b.CaliberId == brass.CaliberId && b.ManufacturerId == brass.ManufacturerId && b.MaterialId == brass.MaterialId && brass.TimesFired == 0).Any())
                    {
                        var existingBrass = this.brasses.OfType<Brass>().Where(b => b.CaliberId == brass.CaliberId && b.ManufacturerId == brass.ManufacturerId && b.MaterialId == brass.MaterialId && b.TimesFired == 0).First();
                        brassId = existingBrass.Id;
                    }
                    else
                    {
                        brass.TimesFired = 0;
                        brassId = this.brassService.Add(brass);
                    }

                    Bullet existingBullet;
                    int bulletId;
                    var calDiameter = this.calibers.OfType<Caliber>().Where(c => c.Id == brass.CaliberId).First();
                    bullet.Diameter = calDiameter.Diameter;
                    if (this.bullets.OfType<Bullet>().Where(b => b.Diameter == bullet.Diameter && b.ManufacturerId == bullet.ManufacturerId && b.MaterialId == bullet.MaterialId && b.Mass == bullet.Mass).Any())
                    {
                        existingBullet = this.bullets.OfType<Bullet>().Where(b => b.Diameter == bullet.Diameter && b.ManufacturerId == bullet.ManufacturerId && b.MaterialId == bullet.MaterialId && b.Mass == bullet.Mass).First();
                        bulletId = existingBullet.Id;
                    }
                    else
                    {
                        bullet.DiameterUnitId = calDiameter.DiameterUnitId;
                        bulletId = this.bulletService.Add(bullet);
                    }

                    cartridgeLoad.BulletId = bulletId;
                    var cartridgeLoadId = this.cartridgeLoadService.Add(cartridgeLoad);

                    var cartridge = new Cartridge
                    {
                        CartridgeLoadId = cartridgeLoadId,
                        BrassId = brassId,
                        ManufacturerId = brass.ManufacturerId
                    };
                    var cartridgeId = this.cartridgeService.Add(cartridge);

                    if (addToStore)
                    {

                    }

                    transaction.Complete();

                }

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }

        public JsonResult GetBrassesByCaliber(int caliberId)
        {
            var brasses = this.brassViews.Where(b => b.CaliberId == caliberId);

            var brassList = new List<string>();

            foreach (var b in brasses)
            {
                brassList.Add(b.Id.ToString() + ":" + (b.BrassName + " X" + b.TimesFired + " fired"));
            }
            return Json(brassList);
        }
    }
}