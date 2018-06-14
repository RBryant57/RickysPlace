using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class UnitMap : EntityTypeConfiguration<Unit>
    {
        public UnitMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Plural)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Abbreviation)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Unit");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Plural).HasColumnName("Plural");
            this.Property(t => t.Abbreviation).HasColumnName("Abbreviation");
            this.Property(t => t.UnitTypeId).HasColumnName("UnitTypeId");
            this.Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            this.HasRequired(t => t.UnitType)
                .WithMany(t => t.Units)
                .HasForeignKey(d => d.UnitTypeId);

        }
    }
}
