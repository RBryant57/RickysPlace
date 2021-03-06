//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class ShootingSessionView
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int LocationId { get; set; }
        public string ShootingLocationName { get; set; }
        public string ShootingLocationState { get; set; }
        public string ShootingLocationLocation { get; set; }
        public string ShootingLocationNotes { get; set; }
        public int GunId { get; set; }
        public string GunViewSerialNumber { get; set; }
        public string GunViewName { get; set; }
        public string GunViewGunName { get; set; }
        public int GunViewCaliberId { get; set; }
        public string GunViewCaliberViewName { get; set; }
        public decimal GunViewCaliberViewDiameter { get; set; }
        public int GunViewCaliberViewDiameterUnitId { get; set; }
        public string GunViewCaliberViewDiameterUnitViewName { get; set; }
        public string GunViewCaliberViewDiameterUnitViewPlural { get; set; }
        public string GunViewCaliberViewDiameterUnitViewAbbreviation { get; set; }
        public int GunViewCaliberViewDiameterUnitViewUnitTypeId { get; set; }
        public string GunViewCaliberViewDiameterUnitViewUnitTypeName { get; set; }
        public string GunViewCaliberViewDiameterUnitViewUnitTypeNotes { get; set; }
        public string GunViewCaliberViewDiameterUnitViewNotes { get; set; }
        public int GunViewCaliberViewPrimerTypeId { get; set; }
        public string GunViewCaliberViewPrimerTypeName { get; set; }
        public string GunViewCaliberViewPrimerTypeAbbreviation { get; set; }
        public string GunViewCaliberViewPrimerTypeNotes { get; set; }
        public int GunViewCaliberViewSortOrder { get; set; }
        public string GunViewCaliberViewNotes { get; set; }
        public int GunViewManufacturerId { get; set; }
        public string GunViewManufacturerName { get; set; }
        public string GunViewManufacturerShortName { get; set; }
        public string GunViewManufacturerAddress { get; set; }
        public string GunViewManufacturerCity { get; set; }
        public string GunViewManufacturerState { get; set; }
        public string GunViewManufacturerZip { get; set; }
        public string GunViewManufacturerURL { get; set; }
        public string GunViewManufacturerNotes { get; set; }
        public int GunViewCapacity { get; set; }
        public decimal GunViewBarrelLength { get; set; }
        public int GunViewGunTypeId { get; set; }
        public string GunViewGunTypeName { get; set; }
        public string GunViewGunTypeNotes { get; set; }
        public decimal GunViewCost { get; set; }
        public System.DateTime GunViewAcquisitionDate { get; set; }
        public Nullable<System.DateTime> GunViewRetireDate { get; set; }
        public string GunViewDetails { get; set; }
        public string GunViewNotes { get; set; }
        public int CartridgeId { get; set; }
        public string CartridgeViewName { get; set; }
        public string CartridgeViewCartridgeName { get; set; }
        public int CartridgeViewCartridgeLoadId { get; set; }
        public string CartridgeViewCartridgeLoadViewName { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewBulletId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewBulletName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewBulletFullName { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewBulletViewBulletTypeId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewBulletTypeName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewBulletTypeAbbreviation { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewBulletTypeNotes { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewBulletViewMaterialId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewMaterialName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewMaterialNotes { get; set; }
        public Nullable<decimal> CartridgeViewCartridgeLoadViewBulletViewDiameter { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewBulletViewDiameterUnitId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewPlural { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewAbbreviation { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewUnitTypeId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewUnitTypeName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewUnitTypeNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewDiameterUnitViewNotes { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewBulletViewMass { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewBulletViewMassUnitId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewMassUnitViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewMassUnitViewPlural { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewMassUnitViewAbbreviation { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewBulletViewMassUnitViewUnitTypeId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewMassUnitViewUnitTypeName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewMassUnitViewUnitTypeNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewMassUnitViewNotes { get; set; }
        public Nullable<decimal> CartridgeViewCartridgeLoadViewBulletViewSectionalDenisity { get; set; }
        public Nullable<decimal> CartridgeViewCartridgeLoadViewBulletViewBallisticCoefficient { get; set; }
        public Nullable<decimal> CartridgeViewCartridgeLoadViewBulletViewLength { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewBulletViewLengthUnitId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewPlural { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewAbbreviation { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewUnitTypeId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewUnitTypeName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewUnitTypeNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewLengthUnitViewNotes { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewBulletViewManufacturerId { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewManufacturerName { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewManufacturerAddress { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewManufacturerCity { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewManufacturerState { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewManufacturerZip { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewManufacturerURL { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewManufacturerNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewBulletViewNotes { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewPowderId { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewPowderName { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewPowderViewManufacturerId { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewManufacturerName { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewManufacturerAddress { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewManufacturerCity { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewManufacturerState { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewManufacturerZip { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewManufacturerURL { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewManufacturerNotes { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewPowderViewPowderTypeId { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewPowderTypeName { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewPowderTypeNotes { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewPowderViewPowderShapeId { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewPowderShapeName { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewPowderShapeNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderViewNotes { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewPowderWeight { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewPowderWeightUnitId { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderWeightUnitViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderWeightUnitViewPlural { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderWeightUnitViewAbbreviation { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewPowderWeightUnitViewUnitTypeId { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderWeightUnitViewUnitTypeName { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderWeightUnitViewUnitTypeNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewPowderWeightUnitViewNotes { get; set; }
        public Nullable<decimal> CartridgeViewCartridgeLoadViewCOL { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewCOLUnitId { get; set; }
        public string CartridgeViewCartridgeLoadViewCOLUnitViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewCOLUnitViewPlural { get; set; }
        public string CartridgeViewCartridgeLoadViewCOLUnitViewAbbreviation { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewCOLUnitViewUnitTypeId { get; set; }
        public string CartridgeViewCartridgeLoadViewCOLUnitViewUnitTypeName { get; set; }
        public string CartridgeViewCartridgeLoadViewCOLUnitViewUnitTypeNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewCOLUnitViewNotes { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewVelocity { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewVelocityUnitId { get; set; }
        public string CartridgeViewCartridgeLoadViewVelocityUnitViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewVelocityUnitViewPlural { get; set; }
        public string CartridgeViewCartridgeLoadViewVelocityUnitViewAbbreviation { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewVelocityUnitViewUnitTypeId { get; set; }
        public string CartridgeViewCartridgeLoadViewVelocityUnitViewUnitTypeName { get; set; }
        public string CartridgeViewCartridgeLoadViewVelocityUnitViewUnitTypeNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewVelocityUnitViewNotes { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewPressure { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewPressureUnitId { get; set; }
        public string CartridgeViewCartridgeLoadViewPressureUnitViewName { get; set; }
        public string CartridgeViewCartridgeLoadViewPressureUnitViewPlural { get; set; }
        public string CartridgeViewCartridgeLoadViewPressureUnitViewAbbreviation { get; set; }
        public Nullable<int> CartridgeViewCartridgeLoadViewPressureUnitViewUnitTypeId { get; set; }
        public string CartridgeViewCartridgeLoadViewPressureUnitViewUnitTypeName { get; set; }
        public string CartridgeViewCartridgeLoadViewPressureUnitViewUnitTypeNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewPressureUnitViewNotes { get; set; }
        public string CartridgeViewCartridgeLoadViewNotes { get; set; }
        public int CartridgeViewBrassId { get; set; }
        public Nullable<int> CartridgeViewBrassViewParentId { get; set; }
        public string CartridgeViewBrassViewName { get; set; }
        public string BrassViewBrassName { get; set; }
        public Nullable<decimal> CartridgeViewBrassViewLength { get; set; }
        public Nullable<int> CartridgeViewBrassViewLengthUnitId { get; set; }
        public string CartridgeViewBrassViewLengthUnitViewName { get; set; }
        public string CartridgeViewBrassViewLengthUnitViewPlural { get; set; }
        public string CartridgeViewBrassViewLengthUnitViewAbbreviation { get; set; }
        public Nullable<int> CartridgeViewBrassViewLengthUnitViewUnitTypeId { get; set; }
        public string CartridgeViewBrassViewLengthUnitViewUnitTypeName { get; set; }
        public string CartridgeViewBrassViewLengthUnitViewUnitTypeNotes { get; set; }
        public string CartridgeViewBrassViewLengthUnitViewNotes { get; set; }
        public Nullable<int> CartridgeViewBrassViewMaterialId { get; set; }
        public string CartridgeViewBrassViewMaterialName { get; set; }
        public string CartridgeViewBrassViewMaterialNotes { get; set; }
        public Nullable<int> CartridgeViewBrassViewManufacturerId { get; set; }
        public string CartridgeViewBrassViewManufacturerName { get; set; }
        public string CartridgeViewBrassViewManufacturerAddress { get; set; }
        public string CartridgeViewBrassViewManufacturerCity { get; set; }
        public string CartridgeViewBrassViewManufacturerState { get; set; }
        public string CartridgeViewBrassViewManufacturerZip { get; set; }
        public string CartridgeViewBrassViewManufacturerURL { get; set; }
        public string CartridgeViewBrassViewManufacturerNotes { get; set; }
        public Nullable<int> CartridgeViewBrassViewTimesFired { get; set; }
        public string CartridgeViewBrassViewNotes { get; set; }
        public Nullable<int> CartridgeViewPrimerId { get; set; }
        public string CartridgeViewPrimerViewName { get; set; }
        public string CartridgeViewPrimerViewFullName { get; set; }
        public string CartridgeViewPrimerViewPrimerName { get; set; }
        public Nullable<int> CartridgeViewPrimerViewPrimerTypeId { get; set; }
        public string CartridgeViewPrimerViewPrimerTypeName { get; set; }
        public string CartridgeViewPrimerViewPrimerTypeAbbreviation { get; set; }
        public string CartridgeViewPrimerViewPrimerTypeNotes { get; set; }
        public Nullable<int> CartridgeViewPrimerViewManufacturerId { get; set; }
        public string CartridgeViewPrimerViewManufacturerName { get; set; }
        public string CartridgeViewPrimerViewManufacturerAddress { get; set; }
        public string CartridgeViewPrimerViewManufacturerCity { get; set; }
        public string CartridgeViewPrimerViewManufacturerState { get; set; }
        public string CartridgeViewPrimerViewManufacturerZip { get; set; }
        public string CartridgeViewPrimerViewManufacturerURL { get; set; }
        public string CartridgeViewPrimerViewManufacturerNotes { get; set; }
        public string CartridgeViewPrimerViewNotes { get; set; }
        public int CartridgeViewManufacturerId { get; set; }
        public string CartridgeViewManufacturerName { get; set; }
        public string ManufacturerShortName { get; set; }
        public string CartridgeViewManufacturerAddress { get; set; }
        public string CartridgeViewManufacturerCity { get; set; }
        public string CartridgeViewManufacturerState { get; set; }
        public string CartridgeViewManufacturerZip { get; set; }
        public string CartridgeViewManufacturerURL { get; set; }
        public string CartridgeViewManufacturerNotes { get; set; }
        public string CartridgeViewNotes { get; set; }
        public int Rounds { get; set; }
        public Nullable<int> Retention { get; set; }
        public string Notes { get; set; }
    }
}
