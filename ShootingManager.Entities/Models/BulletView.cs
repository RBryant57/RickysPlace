using System;
using System.Collections.Generic;

namespace ShootingManager.Entities.Models
{
    public partial class BulletView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BulletName { get; set; }
        public string BulletFullName { get; set; }
        public int BulletTypeId { get; set; }
        public string BulletTypeName { get; set; }
        public string BulletTypeAbbreviation { get; set; }
        public string BulletTypeNotes { get; set; }
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public string MaterialNotes { get; set; }
        public decimal Diameter { get; set; }
        public int DiameterUnitId { get; set; }
        public string DiameterUnitViewName { get; set; }
        public string DiameterUnitViewPlural { get; set; }
        public string DiameterUnitViewAbbreviation { get; set; }
        public int DiameterUnitViewUnitTypeId { get; set; }
        public string DiameterUnitViewUnitTypeName { get; set; }
        public string DiameterUnitViewUnitTypeNotes { get; set; }
        public string DiameterUnitViewNotes { get; set; }
        public int Mass { get; set; }
        public int MassUnitId { get; set; }
        public string MassUnitViewName { get; set; }
        public string MassUnitViewPlural { get; set; }
        public string MassUnitViewAbbreviation { get; set; }
        public int MassUnitViewUnitTypeId { get; set; }
        public string MassUnitViewUnitTypeName { get; set; }
        public string MassUnitViewUnitTypeNotes { get; set; }
        public string MassUnitViewNotes { get; set; }
        public decimal? SectionalDensity { get; set; }
        public decimal? BallisticCoefficient { get; set; }
        public decimal? Length { get; set; }
        public int? LengthUnitId { get; set; }
        public string LengthUnitViewName { get; set; }
        public string LengthUnitViewPlural { get; set; }
        public string LengthUnitViewAbbreviation { get; set; }
        public int? LengthUnitViewUnitTypeId { get; set; }
        public string LengthUnitViewUnitTypeName { get; set; }
        public string LengthUnitViewUnitTypeNotes { get; set; }
        public string LengthUnitViewNotes { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerShortName { get; set; }
        public string ManufacturerAddress { get; set; }
        public string ManufacturerCity { get; set; }
        public string ManufacturerState { get; set; }
        public string ManufacturerZip { get; set; }
        public string ManufacturerURL { get; set; }
        public string ManufacturerNotes { get; set; }
        public string Notes { get; set; }
        public int CaliberViewId { get; set; }
        public string CaliberViewName { get; set; }
        public int CaliberViewSortOrder { get; set; }
    }
}
