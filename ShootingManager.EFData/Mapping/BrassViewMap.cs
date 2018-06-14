using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class BrassViewMap : EntityTypeConfiguration<BrassView>
    {
        public BrassViewMap()
        {
            // Table & Column Mappings
            this.ToTable("BrassView");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.BrassFullName).HasColumnName("BrassFullName");
            this.Property(t => t.ParentBrassFullName).HasColumnName("ParentBrassFullName");
            this.Property(t => t.CaliberId).HasColumnName("CaliberId");
            this.Property(t => t.CaliberViewName).HasColumnName("CaliberViewName");
            this.Property(t => t.CaliberViewDiameter).HasColumnName("CaliberViewDiameter");
            this.Property(t => t.CaliberViewDiameterUnitId).HasColumnName("CaliberViewDiameterUnitId");
            this.Property(t => t.CaliberViewDiameterUnitViewName).HasColumnName("CaliberViewDiameterUnitViewName");
            this.Property(t => t.CaliberViewDiameterUnitViewPlural).HasColumnName("CaliberViewDiameterUnitViewPlural");
            this.Property(t => t.CaliberViewDiameterUnitViewAbbreviation).HasColumnName("CaliberViewDiameterUnitViewAbbreviation");
            this.Property(t => t.CaliberViewDiameterUnitViewUnitTypeId).HasColumnName("CaliberViewDiameterUnitViewUnitTypeId");
            this.Property(t => t.CaliberViewDiameterUnitViewUnitTypeName).HasColumnName("CaliberViewDiameterUnitViewUnitTypeName");
            this.Property(t => t.CaliberViewDiameterUnitViewUnitTypeNotes).HasColumnName("CaliberViewDiameterUnitViewUnitTypeNotes");
            this.Property(t => t.CaliberViewDiameterUnitViewNotes).HasColumnName("CaliberViewDiameterUnitViewNotes");
            this.Property(t => t.CaliberViewPrimerTypeId).HasColumnName("CaliberViewPrimerTypeId");
            this.Property(t => t.CaliberViewPrimerTypeName).HasColumnName("CaliberViewPrimerTypeName");
            this.Property(t => t.CaliberViewPrimerTypeAbbreviation).HasColumnName("CaliberViewPrimerTypeAbbreviation");
            this.Property(t => t.CaliberViewPrimerTypeNotes).HasColumnName("CaliberViewPrimerTypeNotes");
            this.Property(t => t.CaliberViewSortOrder).HasColumnName("CaliberViewSortOrder");
            this.Property(t => t.CaliberViewNotes).HasColumnName("CaliberViewNotes");
            //this.Property(t => t.Length).HasColumnName("Length");
            //this.Property(t => t.LengthUnitId).HasColumnName("LengthUnitId");
            //this.Property(t => t.LengthUnitViewName).HasColumnName("LengthUnitViewName");
            //this.Property(t => t.LengthUnitViewPlural).HasColumnName("LengthUnitViewPlural");
            //this.Property(t => t.LengthUnitViewAbbreviation).HasColumnName("LengthUnitViewAbbreviation");
            //this.Property(t => t.LengthUnitViewUnitTypeId).HasColumnName("LengthUnitViewUnitTypeId");
            //this.Property(t => t.LengthUnitViewUnitTypeName).HasColumnName("LengthUnitViewUnitTypeName");
            //this.Property(t => t.LengthUnitViewUnitTypeNotes).HasColumnName("LengthUnitViewUnitTypeNotes");
            //this.Property(t => t.LengthUnitViewNotes).HasColumnName("LengthUnitViewNotes");
            this.Property(t => t.MaterialId).HasColumnName("MaterialId");
            this.Property(t => t.MaterialName).HasColumnName("MaterialName");
            this.Property(t => t.MaterialNotes).HasColumnName("MaterialNotes");
            this.Property(t => t.ManufacturerId).HasColumnName("ManufacturerId");
            this.Property(t => t.ManufacturerName).HasColumnName("ManufacturerName");
            this.Property(t => t.ManufacturerAddress).HasColumnName("ManufacturerAddress");
            this.Property(t => t.ManufacturerCity).HasColumnName("ManufacturerCity");
            this.Property(t => t.ManufacturerState).HasColumnName("ManufacturerState");
            this.Property(t => t.ManufacturerZip).HasColumnName("ManufacturerZip");
            this.Property(t => t.ManufacturerURL).HasColumnName("ManufacturerURL");
            this.Property(t => t.ManufacturerNotes).HasColumnName("ManufacturerNotes");
            this.Property(t => t.TimesFired).HasColumnName("TimesFired");
            this.Property(t => t.Notes).HasColumnName("Notes");
        }
    }
}
