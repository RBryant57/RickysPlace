using System;
using System.Collections;
using System.Collections.Generic;

namespace ShootingManager.Entities.Models
{
    public partial class GunView
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string GunName { get; set; }
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
        public decimal CaliberViewBrassLength { get; set; }
        public int CaliberViewBrassLengthUnitId { get; set; }
        public string CaliberViewBrassLengthUnitViewName { get; set; }
        public string CaliberViewBrassLengthUnitViewPlural { get; set; }
        public string CaliberViewBrassLengthUnitViewAbbreviation { get; set; }
        public int CaliberViewBrassLengthUnitViewUnitTypeId { get; set; }
        public string CaliberViewBrassLengthUnitViewUnitTypeName { get; set; }
        public string CaliberViewBrassLengthUnitViewUnitTypeNotes { get; set; }
        public string CaliberViewBrassLengthUnitViewNotes { get; set; }
        public int CaliberViewPrimerTypeId { get; set; }
        public string CaliberViewPrimerTypeName { get; set; }
        public string CaliberViewPrimerTypeAbbreviation { get; set; }
        public string CaliberViewPrimerTypeNotes { get; set; }
        public int CaliberViewSortOrder { get; set; }
        public string CaliberViewNotes { get; set; }
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; }
        public string ManufacturerShortName { get; set; }
        public string ManufacturerAddress { get; set; }
        public string ManufacturerCity { get; set; }
        public string ManufacturerState { get; set; }
        public string ManufacturerZip { get; set; }
        public string ManufacturerURL { get; set; }
        public string ManufacturerNotes { get; set; }
        public int SellerId { get; set; }
        public string SellerName { get; set; }
        public string SellerShortName { get; set; }
        public string SellerAddress { get; set; }
        public string SellerCity { get; set; }
        public string SellerState { get; set; }
        public string SellerZip { get; set; }
        public string SellerURL { get; set; }
        public string SellerNotes { get; set; }
        public Nullable<int> BuyerId { get; set; }
        public string BuyerName { get; set; }
        public string BuyerShortName { get; set; }
        public string BuyerAddress { get; set; }
        public string BuyerCity { get; set; }
        public string BuyerState { get; set; }
        public string BuyerZip { get; set; }
        public string BuyerURL { get; set; }
        public string BuyerNotes { get; set; }
        public int Capacity { get; set; }
        public decimal BarrelLength { get; set; }
        public int BarrelLengthUnitId { get; set; }
        public string LengthUnitViewName { get; set; }
        public string LengthUnitViewPlural { get; set; }
        public string LengthUnitViewAbbreviation { get; set; }
        public int LengthUnitViewUnitTypeId { get; set; }
        public string LengthUnitViewUnitTypeName { get; set; }
        public string LengthUnitViewUnitTypeNotes { get; set; }
        public string LengthUnitViewNotes { get; set; }
        public int GunTypeId { get; set; }
        public string GunTypeName { get; set; }
        public string GunTypeNotes { get; set; }
        public decimal Cost { get; set; }
        public System.DateTime AcquisitionDate { get; set; }
        public Nullable<System.DateTime> RetireDate { get; set; }
        public string Details { get; set; }
        public string Notes { get; set; }
        public List<CaliberInfo> AdditionalCalibers { get; set; }
    }

    public struct CaliberInfo : IEnumerable
    {
        public int Id;
        public string Name;

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
