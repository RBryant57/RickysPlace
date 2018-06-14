using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class CaliberViewMap : EntityTypeConfiguration<CaliberView>
    {
        public CaliberViewMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.Name, t.Diameter, t.DiameterUnitId, t.DiameterUnitViewName, t.DiameterUnitViewPlural, t.DiameterUnitViewAbbreviation, t.DiameterUnitViewUnitTypeId, t.DiameterUnitViewUnitTypeName, t.BrassLength, t.BrassLengthUnitId, t.BrassLengthUnitViewName, t.BrassLengthUnitViewPlural, t.BrassLengthUnitViewAbbreviation, t.BrassLengthUnitViewUnitTypeId, t.BrassLengthUnitViewUnitTypeName, t.PrimerTypeId, t.PrimerTypeName, t.PrimerTypeAbbreviation, t.SortOrder });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Diameter)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DiameterUnitId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DiameterUnitViewName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.DiameterUnitViewPlural)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.DiameterUnitViewAbbreviation)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.DiameterUnitViewUnitTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DiameterUnitViewUnitTypeName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.BrassLength)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.BrassLengthUnitId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.BrassLengthUnitViewName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.BrassLengthUnitViewPlural)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.BrassLengthUnitViewAbbreviation)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.BrassLengthUnitViewUnitTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.BrassLengthUnitViewUnitTypeName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PrimerTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PrimerTypeName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.PrimerTypeAbbreviation)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.SortOrder)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("CaliberView");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Diameter).HasColumnName("Diameter");
            this.Property(t => t.DiameterUnitId).HasColumnName("DiameterUnitId");
            this.Property(t => t.DiameterUnitViewName).HasColumnName("DiameterUnitViewName");
            this.Property(t => t.DiameterUnitViewPlural).HasColumnName("DiameterUnitViewPlural");
            this.Property(t => t.DiameterUnitViewAbbreviation).HasColumnName("DiameterUnitViewAbbreviation");
            this.Property(t => t.DiameterUnitViewUnitTypeId).HasColumnName("DiameterUnitViewUnitTypeId");
            this.Property(t => t.DiameterUnitViewUnitTypeName).HasColumnName("DiameterUnitViewUnitTypeName");
            this.Property(t => t.DiameterUnitViewUnitTypeNotes).HasColumnName("DiameterUnitViewUnitTypeNotes");
            this.Property(t => t.DiameterUnitViewNotes).HasColumnName("DiameterUnitViewNotes");
            this.Property(t => t.BrassLength).HasColumnName("BrassLength");
            this.Property(t => t.BrassLengthUnitId).HasColumnName("BrassLengthUnitId");
            this.Property(t => t.BrassLengthUnitViewName).HasColumnName("BrassLengthUnitViewName");
            this.Property(t => t.BrassLengthUnitViewPlural).HasColumnName("BrassLengthUnitViewPlural");
            this.Property(t => t.BrassLengthUnitViewAbbreviation).HasColumnName("BrassLengthUnitViewAbbreviation");
            this.Property(t => t.BrassLengthUnitViewUnitTypeId).HasColumnName("BrassLengthUnitViewUnitTypeId");
            this.Property(t => t.BrassLengthUnitViewUnitTypeName).HasColumnName("BrassLengthUnitViewUnitTypeName");
            this.Property(t => t.BrassLengthUnitViewUnitTypeNotes).HasColumnName("BrassLengthUnitViewUnitTypeNotes");
            this.Property(t => t.BrassLengthUnitViewNotes).HasColumnName("BrassLengthUnitViewNotes");
            this.Property(t => t.PrimerTypeId).HasColumnName("PrimerTypeId");
            this.Property(t => t.PrimerTypeName).HasColumnName("PrimerTypeName");
            this.Property(t => t.PrimerTypeAbbreviation).HasColumnName("PrimerTypeAbbreviation");
            this.Property(t => t.PrimerTypeNotes).HasColumnName("PrimerTypeNotes");
            this.Property(t => t.SortOrder).HasColumnName("SortOrder");
            this.Property(t => t.Notes).HasColumnName("Notes");
        }
    }
}
