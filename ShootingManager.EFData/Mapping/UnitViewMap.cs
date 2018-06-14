using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class UnitViewMap : EntityTypeConfiguration<UnitView>
    {
        public UnitViewMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Id, t.Name, t.Plural, t.Abbreviation, t.UnitTypeId, t.UnitTypeName });

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Plural)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Abbreviation)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UnitTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.UnitTypeName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("UnitView");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Plural).HasColumnName("Plural");
            this.Property(t => t.Abbreviation).HasColumnName("Abbreviation");
            this.Property(t => t.UnitTypeId).HasColumnName("UnitTypeId");
            this.Property(t => t.UnitTypeName).HasColumnName("UnitTypeName");
            this.Property(t => t.UnitTypeNotes).HasColumnName("UnitTypeNotes");
            this.Property(t => t.Notes).HasColumnName("Notes");
        }
    }
}
