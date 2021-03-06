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
    
    public partial class BrassView
    {
        public int Id { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Name { get; set; }
        public string BrassName { get; set; }
        public string BrassFullName { get; set; }
        public string ParentBrassFullName { get; set; }
        public int CaliberId { get; set; }
        public string CaliberViewName { get; set; }
        public decimal CaliberViewDiameter { get; set; }
        public int CaliberViewDiameterUnitId { get; set; }
        public string CaliberViewDiameterUnitViewName { get; set; }
        public string CaliberViewDiameterUnitViewPlural { get; set; }
        public string CaliberViewDiameterUnitViewAbbreviation { get; set; }
        public int CaliberViewDiameterUnitViewUnitTypeId { get; set; }
        public string CaliberViewDiameterUnitViewUnitTypeName { get; set; }
        public string CaliberViewDiameterUnitViewUnitTypeNotes { get; set; }
        public string CaliberViewDiameterUnitViewNotes { get; set; }
        public int CaliberViewPrimerTypeId { get; set; }
        public string CaliberViewPrimerTypeName { get; set; }
        public string CaliberViewPrimerTypeAbbreviation { get; set; }
        public string CaliberViewPrimerTypeNotes { get; set; }
        public int CaliberViewSortOrder { get; set; }
        public string CaliberViewNotes { get; set; }
        public decimal Length { get; set; }
        public int LengthUnitId { get; set; }
        public string LengthUnitViewName { get; set; }
        public string LengthUnitViewPlural { get; set; }
        public string LengthUnitViewAbbreviation { get; set; }
        public int LengthUnitViewUnitTypeId { get; set; }
        public string LengthUnitViewUnitTypeName { get; set; }
        public string LengthUnitViewUnitTypeNotes { get; set; }
        public string LengthUnitViewNotes { get; set; }
        public int MaterialId { get; set; }
        public string MaterialName { get; set; }
        public string MaterialNotes { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerShortName { get; set; }
        public string ManufacturerAddress { get; set; }
        public string ManufacturerCity { get; set; }
        public string ManufacturerState { get; set; }
        public string ManufacturerZip { get; set; }
        public string ManufacturerURL { get; set; }
        public string ManufacturerNotes { get; set; }
        public int TimesFired { get; set; }
        public string Notes { get; set; }
    }
}
