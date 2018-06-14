using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class BulletViewMap : EntityTypeConfiguration<BulletView>
    {
        public BulletViewMap()
        {

            // Table & Column Mappings
            this.ToTable("BulletView");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.BulletName).HasColumnName("BulletName");
            this.Property(t => t.BulletFullName).HasColumnName("BulletFullName");
            this.Property(t => t.BulletTypeId).HasColumnName("BulletTypeId");
            this.Property(t => t.BulletTypeName).HasColumnName("BulletTypeName");
            this.Property(t => t.BulletTypeAbbreviation).HasColumnName("BulletTypeAbbreviation");
            this.Property(t => t.BulletTypeNotes).HasColumnName("BulletTypeNotes");
            this.Property(t => t.MaterialId).HasColumnName("MaterialId");
            this.Property(t => t.MaterialName).HasColumnName("MaterialName");
            this.Property(t => t.MaterialNotes).HasColumnName("MaterialNotes");
            this.Property(t => t.Diameter).HasColumnName("Diameter");
            this.Property(t => t.DiameterUnitId).HasColumnName("DiameterUnitId");
            this.Property(t => t.DiameterUnitViewName).HasColumnName("DiameterUnitViewName");
            this.Property(t => t.DiameterUnitViewPlural).HasColumnName("DiameterUnitViewPlural");
            this.Property(t => t.DiameterUnitViewAbbreviation).HasColumnName("DiameterUnitViewAbbreviation");
            this.Property(t => t.DiameterUnitViewUnitTypeId).HasColumnName("DiameterUnitViewUnitTypeId");
            this.Property(t => t.DiameterUnitViewUnitTypeName).HasColumnName("DiameterUnitViewUnitTypeName");
            this.Property(t => t.DiameterUnitViewUnitTypeNotes).HasColumnName("DiameterUnitViewUnitTypeNotes");
            this.Property(t => t.DiameterUnitViewNotes).HasColumnName("DiameterUnitViewNotes");
            this.Property(t => t.Mass).HasColumnName("Mass");
            this.Property(t => t.MassUnitId).HasColumnName("MassUnitId");
            this.Property(t => t.MassUnitViewName).HasColumnName("MassUnitViewName");
            this.Property(t => t.MassUnitViewPlural).HasColumnName("MassUnitViewPlural");
            this.Property(t => t.MassUnitViewAbbreviation).HasColumnName("MassUnitViewAbbreviation");
            this.Property(t => t.MassUnitViewUnitTypeId).HasColumnName("MassUnitViewUnitTypeId");
            this.Property(t => t.MassUnitViewUnitTypeName).HasColumnName("MassUnitViewUnitTypeName");
            this.Property(t => t.MassUnitViewUnitTypeNotes).HasColumnName("MassUnitViewUnitTypeNotes");
            this.Property(t => t.MassUnitViewNotes).HasColumnName("MassUnitViewNotes");
            this.Property(t => t.SectionalDensity).HasColumnName("SectionalDensity");
            this.Property(t => t.BallisticCoefficient).HasColumnName("BallisticCoefficient");
            this.Property(t => t.Length).HasColumnName("Length");
            this.Property(t => t.LengthUnitId).HasColumnName("LengthUnitId");
            this.Property(t => t.LengthUnitViewName).HasColumnName("LengthUnitViewName");
            this.Property(t => t.LengthUnitViewPlural).HasColumnName("LengthUnitViewPlural");
            this.Property(t => t.LengthUnitViewAbbreviation).HasColumnName("LengthUnitViewAbbreviation");
            this.Property(t => t.LengthUnitViewUnitTypeId).HasColumnName("LengthUnitViewUnitTypeId");
            this.Property(t => t.LengthUnitViewUnitTypeName).HasColumnName("LengthUnitViewUnitTypeName");
            this.Property(t => t.LengthUnitViewUnitTypeNotes).HasColumnName("LengthUnitViewUnitTypeNotes");
            this.Property(t => t.LengthUnitViewNotes).HasColumnName("LengthUnitViewNotes");
            this.Property(t => t.ManufacturerId).HasColumnName("ManufacturerId");
            this.Property(t => t.ManufacturerName).HasColumnName("ManufacturerName");
            this.Property(t => t.ManufacturerAddress).HasColumnName("ManufacturerAddress");
            this.Property(t => t.ManufacturerCity).HasColumnName("ManufacturerCity");
            this.Property(t => t.ManufacturerState).HasColumnName("ManufacturerState");
            this.Property(t => t.ManufacturerZip).HasColumnName("ManufacturerZip");
            this.Property(t => t.ManufacturerURL).HasColumnName("ManufacturerURL");
            this.Property(t => t.ManufacturerNotes).HasColumnName("ManufacturerNotes");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.CaliberViewId).HasColumnName("CaliberViewId");
            this.Property(t => t.CaliberViewName).HasColumnName("CaliberViewName");
            this.Property(t => t.CaliberViewSortOrder).HasColumnName("CaliberViewSortOrder");
        }
    }
}
