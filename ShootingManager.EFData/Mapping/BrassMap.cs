using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using ShootingManager.Entities.Models;

namespace ShootingManager.EFData.Mapping
{
    public class BrassMap : EntityTypeConfiguration<Brass>
    {
        public BrassMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);
            this.Property(t => t.Length).HasPrecision(7, 3);

            // Table & Column Mappings
            this.ToTable("Brass");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ParentId).HasColumnName("ParentId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CaliberId).HasColumnName("CaliberId");
            this.Property(t => t.Length).HasColumnName("Length");
            this.Property(t => t.LengthUnitId).HasColumnName("LengthUnitId");
            this.Property(t => t.MaterialId).HasColumnName("MaterialId");
            this.Property(t => t.ManufacturerId).HasColumnName("ManufacturerId");
            this.Property(t => t.TimesFired).HasColumnName("TimesFired");
            this.Property(t => t.Notes).HasColumnName("Notes");

            // Relationships
            this.HasRequired(t => t.Caliber)
                .WithMany(t => t.Brasses)
                .HasForeignKey(d => d.CaliberId);
            this.HasRequired(t => t.Manufacturer)
                .WithMany(t => t.Brasses)
                .HasForeignKey(d => d.ManufacturerId);
            this.HasRequired(t => t.Material)
                .WithMany(t => t.Brasses)
                .HasForeignKey(d => d.MaterialId);
            this.HasRequired(t => t.LengthUnit)
                .WithMany(t => t.Brasses)
                .HasForeignKey(d => d.LengthUnitId);

        }
    }
}
